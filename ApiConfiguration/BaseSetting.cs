namespace ApiConfiguration
{
    public abstract class BaseSetting
    {
        protected abstract void CommonSettings();
        
        protected abstract void InitProduct();
        protected abstract void InitLocal();
        protected abstract void InitDev();

        protected BaseSetting(EEnvironment environment)
        {
            CommonSettings();
            switch (environment)
            {
                case EEnvironment.Local:
                    {
                        InitLocal();
                        break;
                    }
                case EEnvironment.Dev:
                    {
                        InitDev();
                        break;
                    }
                case EEnvironment.Product:
                    {
                        InitProduct();
                        break;
                    }
            }
        }
    }
}
