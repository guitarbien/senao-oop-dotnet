namespace Service.Handler
{
    public interface IHandler
    {
        byte[] perform(Candidate candidate, byte[] target);
    }
}