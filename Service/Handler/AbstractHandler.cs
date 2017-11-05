namespace Service.Handler
{
    public abstract class AbstractHandler : IHandler
    {

        public virtual byte[] perform(Candidate candidate, byte[] target)
        {
            return target;
        }
    }
}