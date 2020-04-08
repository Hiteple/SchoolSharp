namespace Etapa1.Interfaces
{
    // I'll define what the interface has: the classes that implements this need to define the logic
    public interface IAddress
    {
        public string Address { get; set; }

        void ClearAddress();
    }
}