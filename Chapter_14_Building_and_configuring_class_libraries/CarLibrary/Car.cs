namespace CarLibrary
{
    /// <summary>
    /// Представляет состояние двигателя.
    /// </summary>
    public enum EngineState
    {
        engineAlive,
        engineDead
    }

    /// <summary>
    /// Абстрактный базовый класс в иерархии.
    /// </summary>
    public abstract class Car
    {
        public string PetName { get; set; }
        public int CurrentSpeed { get; set; }
        public int MaxSpeed { get; set; }
        protected EngineState egnState = EngineState.engineAlive;
        public EngineState EngineState => egnState;
        public abstract void TurboBoost();
        public Car() { }
        public Car(string name, int maxSp, int currSp)
        {
            PetName = name;
            MaxSpeed = maxSp;
            CurrentSpeed = currSp;
        }
    }
}
