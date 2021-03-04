namespace Any3.Services.Tests
{
   public abstract class BaseTest
    {
        protected BaseTest()
        {
            InitializeMocks();
        }

        /// <summary> Mock service initialization </summary>
        protected abstract void InitializeMocks();

    }
}
