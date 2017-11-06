namespace Service.Handler
{
    public interface IHandler
    {
        byte[] Perform(Candidate candidate, byte[] target);
    }
}