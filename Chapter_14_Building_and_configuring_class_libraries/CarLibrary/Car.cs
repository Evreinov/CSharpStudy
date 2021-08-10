using System.Windows.Forms;

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

    public enum MusicMedia
    {
        musicCd,
        musicType,
        musicRadio,
        musicMp3
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
        public Car() => MessageBox.Show("CarLibrary Version 2.0!");
        public Car(string name, int maxSp, int currSp)
        {
            MessageBox.Show("CarLibrary Version 2.0!");
            PetName = name;
            MaxSpeed = maxSp;
            CurrentSpeed = currSp;
        }
        public void TurnOnRadio(bool musicOn, MusicMedia mm) => 
            MessageBox.Show(musicOn ? $"Jamming {mm}" : "Quiet time...");
    }
}
