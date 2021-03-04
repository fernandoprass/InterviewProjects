using Any3.Common.Constants;
using Any3.Domain.Contexts.Contracts;
using Any3.Model.Contracts.Dtos;
using Any3.Services.Implementation;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Any3.Services.Tests
{
   public class ContabilidadeServiceTest : BaseTest
   {
      #region Initialization
      private ContabilidadeService contabilidadeService { get; set; }

      private Mock<IContabilidadeContext> contaContabilContextMock;

      /// <summary> The AccountServiceTest class constructor </summary>
      public ContabilidadeServiceTest() : base()
      {
         InitializeMocks();
         contabilidadeService = new ContabilidadeService(contaContabilContextMock.Object);
      }

      /// <summary> Initialize Mocks </summary>
      protected override void InitializeMocks()
      {
         contaContabilContextMock = new Mock<IContabilidadeContext>();
      }

      #endregion

      #region Facts
      [Fact]
      /// <summary> Dada uma lista de contas, sendo nenhuma delas adicionada no mês, retorna as contas do histórico e atualiza seus saldos </summary>
      public void GetSaldoContaContabeis_NenhumaContaAdicionadaNoMes_RetornaContasExistentes()
      {
         // Arrange
         var idsContaContabil = new List<int> { 1, 2, 3, 4, 5 };
         var data = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 10);
         var histCC = new List<ContaContabilSaldoDto>
         {
            GenerateContaContabilSaldoDto(1, "Conta 1", "D", 1000),
            GenerateContaContabilSaldoDto(2, "Conta 2", "D", -500),
            GenerateContaContabilSaldoDto(3, "Conta 3", "C", 2000),
         };

         var lancamentos = new List<ContasPagarReceberSumarizadoDto>
         {
            GenerateLancamentoSumarizadoDto(1, "Conta 1", "D", 200, 100),
            GenerateLancamentoSumarizadoDto(2, "Conta 2", "D", 100, 0),
         };

         contaContabilContextMock.Setup(x => x.GetSaldoHistContasContabeis(idsContaContabil, It.IsAny<string>())).ReturnsAsync(histCC);
         contaContabilContextMock.Setup(x => x.GetLancamentoSumarizadosByConta(idsContaContabil, It.IsAny<DateTime>(), It.IsAny<DateTime>())).ReturnsAsync(lancamentos);

         // Act
         var result = contabilidadeService.GetSaldoContasContabeis(idsContaContabil, data).Result;

         // Assert
         result.Should().NotBeNull();
         result.Should().HaveCount(3);
         var conta1 = result.First(x => x.IdContaContabil == 1);
         conta1.DebitoCredito.Should().Be(Contabilidade.DEBITO);
         conta1.ValorSaldo.Should().Be(1100);
         var conta3 = result.First(x => x.IdContaContabil == 3);
         conta3.DebitoCredito.Should().Be(Contabilidade.CREDITO);
         conta3.ValorSaldo.Should().Be(2000);
      }

      [Fact]
      /// <summary> Dada uma lista de contas e novas contas tendo sido adicionada no mês, retorna as contas do histórico e as novas contas com saldos atualizados</summary>
      public void GetSaldoContaContabeis_DuasContasAdicionadasNoMes_RetornaContasExistentesENovas()
      {
         // Arrange
         var idsContaContabil = new List<int> { 1, 2, 3, 4, 5 };
         var data = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 10);
         var histCC = new List<ContaContabilSaldoDto>
         {
            GenerateContaContabilSaldoDto(1, "Conta 1", "D", 1000),
            GenerateContaContabilSaldoDto(2, "Conta 2", "D", -500),
            GenerateContaContabilSaldoDto(3, "Conta 3", "C", 2000),
         };

         var lancamentos = new List<ContasPagarReceberSumarizadoDto>
         {
            GenerateLancamentoSumarizadoDto(1, "Conta 1", "D", 200, 100),
            GenerateLancamentoSumarizadoDto(4, "Conta 4", "D", 200, 100),
            GenerateLancamentoSumarizadoDto(5, "Conta 5", "C", 200, 100),
         };

         contaContabilContextMock.Setup(x => x.GetSaldoHistContasContabeis(idsContaContabil, It.IsAny<string>())).ReturnsAsync(histCC);
         contaContabilContextMock.Setup(x => x.GetLancamentoSumarizadosByConta(idsContaContabil, It.IsAny<DateTime>(), It.IsAny<DateTime>())).ReturnsAsync(lancamentos);
         
         // Act
         var result = contabilidadeService.GetSaldoContasContabeis(idsContaContabil, data).Result;

         // Assert
         result.Should().NotBeNull();
         result.Should().HaveCount(5);
         var conta1 = result.First(x => x.IdContaContabil == 1);
         conta1.DebitoCredito.Should().Be(Contabilidade.DEBITO);
         conta1.ValorSaldo.Should().Be(1100);
         var conta5 = result.First(x => x.IdContaContabil == 5);
         conta5.DebitoCredito.Should().Be(Contabilidade.CREDITO);
         conta5.ValorSaldo.Should().Be(-100);
      }

      #endregion

      #region Helpers
      /// <summary> Gera um novo objeto ContaContabilSaldoDto </summary>
      /// <param name="idContaContabil"></param>
      /// <param name="descricao"></param>
      /// <param name="dc"></param>
      /// <param name="valorSaldo"></param>
      /// <returns></returns>
      private static ContaContabilSaldoDto GenerateContaContabilSaldoDto(int idContaContabil, string descricao, string dc, decimal valorSaldo)
      {
         return new ContaContabilSaldoDto
         {
            IdContaContabil = idContaContabil,
            Codigo = idContaContabil.ToString().PadLeft(3, '0'),
            Descricao = descricao,
            DebitoCredito = dc,
            ValorSaldo = valorSaldo
         };
      }

      /// <summary> Gera um novo objeto LancamentoSumarizadoDto </summary>
      /// <param name="idContaContabil"></param>
      /// <param name="descricao"></param>
      /// <param name="dc"></param>
      /// <param name="valorDebito"></param>
      /// <param name="valorCrebito"></param>
      /// <returns></returns>
      private static ContasPagarReceberSumarizadoDto GenerateLancamentoSumarizadoDto(int idContaContabil, string descricao, string dc, decimal valorDebito, decimal valorCrebito)
      {
         return new ContasPagarReceberSumarizadoDto
         {
            IdContaContabil = idContaContabil,
            Codigo = idContaContabil.ToString().PadLeft(3, '0'),
            Descricao = descricao,
            DebitoCredito = dc,
            ValorTotalDebito = valorDebito,
            ValorTotalCredito = valorCrebito
         };
      }

      #endregion
   }
}

