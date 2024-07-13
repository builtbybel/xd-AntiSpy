namespace xdAntiSpy
{
    public abstract class SettingsBase
    {
        protected readonly Logger logger;

        public Logger Logger => logger;

        protected SettingsBase(Logger logger)
        {
            this.logger = logger;
        }

        public abstract string ID();

        public abstract string Info();

        public abstract bool CheckFeature();

        public abstract bool DoFeature();

        public abstract bool UndoFeature();
    }
}