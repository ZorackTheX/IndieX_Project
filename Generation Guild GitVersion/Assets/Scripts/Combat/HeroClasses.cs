
[System.Serializable]
public class HeroClasses
{
    public enum HeroClassTypes
    {
        Knight,
        Priest,
        Assassin,
        MysticBinder
    }
    public HeroClassTypes HeroClass;
    /*{
        get
        {
            return HeroClass;
        }
        set
        {
            HeroClass = value;
        }
    }*/
    public float GetStrenghtPerLevel()
    {
        switch(HeroClass)
        {
            case (HeroClassTypes.Knight):
                return 1.0f;
            case (HeroClassTypes.Assassin):
                return 2.0f;
            case (HeroClassTypes.Priest):
                return 1.2f;
            case (HeroClassTypes.MysticBinder):
                return 1.4f;
        }
        return 1.0f;
    }
    public float GetConstitutionPerLevel()
    {
        switch (HeroClass)
        {
            case (HeroClassTypes.Knight):
                return 2.0f;
            case (HeroClassTypes.Assassin):
                return 1.2f;
            case (HeroClassTypes.Priest):
                return 1.0f;
            case (HeroClassTypes.MysticBinder):
                return 1.2f;
        }
        return 1.0f;
    }
    public float GetDefensePerLevel()
    {
        switch (HeroClass)
        {
            case (HeroClassTypes.Knight):
                return 0.05f;
            case (HeroClassTypes.Assassin):
                return 0.3f;
            case (HeroClassTypes.Priest):
                return 0.2f;
            case (HeroClassTypes.MysticBinder):
                return 0.4f;
        }
        return 1.0f;
    }
    public float GetSpeedPerLevel()
    {
        switch (HeroClass)
        {
            case (HeroClassTypes.Knight):
                return 0.5f;
            case (HeroClassTypes.Assassin):
                return 1.5f;
            case (HeroClassTypes.Priest):
                return 1.0f;
            case (HeroClassTypes.MysticBinder):
                return 1.0f;
        }
        return 1.0f;
    }
    public float GetIntelligencePerLevel()
    {
        switch (HeroClass)
        {
            case (HeroClassTypes.Knight):
                return 0.2f;
            case (HeroClassTypes.Assassin):
                return 1.75f;
            case (HeroClassTypes.Priest):
                return 1.75f;
            case (HeroClassTypes.MysticBinder):
                return 1.75f;
        }
        return 1.0f;
    }
}
