using Any3.Common.Extensions;
using FluentAssertions;
using System;
using Xunit;

namespace Any3.Common.Tests
{
   public class DecimalExtensionTest
   {
      /// <summary> Recebe ZERO e retorna TRUE </summary>
      [Fact]
      public void EqualZero_RecebeZero_RetornaTrue()
      {
         var result = DecimalExtension.EqualZero(0);
         result.Should().Be(true);
      }

      /// <summary> Recebe valor diferente de ZERO ou NULL e retorna FALSE </summary>
      [Fact]
      public void EqualZero_RecebeValorDiferenteDeZero_RetornaFalse()
      {
         var result = DecimalExtension.EqualZero(0.001m);
         result.Should().Be(false);

         result = DecimalExtension.EqualZero(-0.0001m);
         result.Should().Be(false);

         result = DecimalExtension.EqualZero(50);
         result.Should().Be(false);

         result = DecimalExtension.EqualZero(-10);
         result.Should().Be(false);

         result = DecimalExtension.EqualZero(null);
         result.Should().Be(false);
      }

      /// <summary> Recebe valor maior que ZERO e retorna TRUE </summary>
      [Fact]
      public void GreaterThanZero_RecebeValorMaiorQueZero_RetornaTrue()
      {
         var result = DecimalExtension.GreaterThanZero(0.001m);
         result.Should().Be(true);

         result = DecimalExtension.GreaterThanZero(100);
         result.Should().Be(true);
      }

      /// <summary> Recebe ZERO, valor menor que ZERO ou NULL e retorna FALSE </summary>
      [Fact]
      public void GreaterThanZero_RecebeValorMenorQueZero_RetornaFalse()
      {
         var result = DecimalExtension.GreaterThanZero(0);
         result.Should().Be(false);

         result = DecimalExtension.GreaterThanZero(-0.0001m);
         result.Should().Be(false);

         result = DecimalExtension.GreaterThanZero(-100);
         result.Should().Be(false);

         result = DecimalExtension.GreaterThanZero(null);
         result.Should().Be(false);
      }

      /// <summary> Recebe valor maior ou igual a ZERO e retorna TRUE </summary>
      [Fact]
      public void GreaterThanOrEqualZero_RecebeValorMaiorOuIgualZero_RetornaTrue()
      {
         var result = DecimalExtension.GreaterThanOrEqualZero(0);
         result.Should().Be(true);

         result = DecimalExtension.GreaterThanOrEqualZero(0.0001m);
         result.Should().Be(true);

         result = DecimalExtension.GreaterThanOrEqualZero(123);
         result.Should().Be(true);
      }

      /// <summary>  Recebe valor menor que ZERO ou NULL e retorna FALSE </summary>
      [Fact]
      public void GreaterThanOrEqualZero_RecebeValorMenorQueZero_RetornaFalse()
      {
         var result = DecimalExtension.GreaterThanOrEqualZero(-0.0001m);
         result.Should().Be(false);

         result = DecimalExtension.GreaterThanOrEqualZero(-10);
         result.Should().Be(false);

         result = DecimalExtension.GreaterThanOrEqualZero(null);
         result.Should().Be(false);
      }

      /// <summary> Recebe valor maior que ZERO e retorna TRUE </summary>
      [Fact]
      public void LessThanZero_RecebeMenorOuIgualZero_RetornaTrue()
      {
         var result = DecimalExtension.LessThanZero(-0.001m);
         result.Should().Be(true);

         result = DecimalExtension.LessThanZero(-100);
         result.Should().Be(true);
      }

      /// <summary> Recebe valor menor ou igal a ZERO ou NULL e retorna FALSE </summary>
      [Fact]
      public void LessThanZero_RecebeValorMaiorOuIgualZero_RetornaFalse()
      {
         var result = DecimalExtension.LessThanZero(0);
         result.Should().Be(false);

         result = DecimalExtension.LessThanZero(0.001m);
         result.Should().Be(false);

         result = DecimalExtension.LessThanZero(10);
         result.Should().Be(false);

         result = DecimalExtension.LessThanZero(null);
         result.Should().Be(false);
      }

      /// <summary> Recebe valor menor ou igual a ZERO e retorna TRUE </summary>
      [Fact]
      public void LessThanOrEqualZero_RecebeMenorOuIgualZero_RetornaTrue()
      {
         var result = DecimalExtension.LessThanOrEqualZero(0);
         result.Should().Be(true);

         result = DecimalExtension.LessThanOrEqualZero(-0.001m);
         result.Should().Be(true);

         result = DecimalExtension.LessThanOrEqualZero(-100);
         result.Should().Be(true);
      }

      /// <summary> Recebe valor maior que ZERO ou NULL e retorna FALSE </summary>
      [Fact]
      public void LessThanOrEqualZero_RecebeValorMaiorOuIgualZero_RetornaFalse()
      {
         var result = DecimalExtension.LessThanOrEqualZero(0.001m);
         result.Should().Be(false);

         result = DecimalExtension.LessThanOrEqualZero(10);
         result.Should().Be(false);

         result = DecimalExtension.LessThanOrEqualZero(null);
         result.Should().Be(false);
      }
   }
}
