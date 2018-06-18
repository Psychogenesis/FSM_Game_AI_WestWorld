using System.ComponentModel.DataAnnotations;

namespace FSMTest
{
    public enum EntityNameType
    {
        [Display(Name = "Miner Bob")]
        Miner
    }

    public class EntityType
    {
        public static string GetEntityName(int name)
        {
            switch((EntityNameType) name)
            {
                case EntityNameType.Miner:
                    return "Miner Bob";
                default:
                    return "UNKNOWN!";
            }
        }
    }
}
