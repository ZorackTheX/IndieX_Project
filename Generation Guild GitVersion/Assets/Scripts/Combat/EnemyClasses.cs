[System.Serializable]
public class EnemyClasses
{

    public enum EnemyTypes
    {
        Spider,
        FlyingMikeWazowski,
        DragonKin
    }
    public EnemyTypes EnemyType;
    /*{
        get
        {
            return EnemyType;
        }
        set
        {
            EnemyType = value;
        }
    }*/
    public float GetStrenghtPerLevel()
    {
        switch (EnemyType)
        {
            case (EnemyTypes.Spider):
                return 0.5f;
            case (EnemyTypes.DragonKin):
                return 1.0f;
            case (EnemyTypes.FlyingMikeWazowski):
                return 0.7f;
        }
        return 1.0f;
    }
    public float GetConstitutionPerLevel()
    {
        switch (EnemyType)
        {
            case (EnemyTypes.Spider):
                return 0.5f;
            case (EnemyTypes.DragonKin):
                return 2.0f;
            case (EnemyTypes.FlyingMikeWazowski):
                return 1.0f;
        }
        return 1.0f;
    }
    public float GetDefensePerLevel()
    {
        switch (EnemyType)
        {
            case (EnemyTypes.Spider):
                return 0.2f;
            case (EnemyTypes.DragonKin):
                return 0.5f;
            case (EnemyTypes.FlyingMikeWazowski):
                return 0.2f;
        }
        return 1.0f;
    }
    public float GetSpeedPerLevel()
    {
        switch (EnemyType)
        {
            case (EnemyTypes.Spider):
                return 1.0f;
            case (EnemyTypes.DragonKin):
                return 1.5f;
            case (EnemyTypes.FlyingMikeWazowski):
                return 2.0f;
        }
        return 1.0f;
    }
    public float GetIntelligencePerLevel()
    {
        switch (EnemyType)
        {
            case (EnemyTypes.Spider):
                return 0.5f;
            case (EnemyTypes.DragonKin):
                return 0.2f;
            case (EnemyTypes.FlyingMikeWazowski):
                return 1.0f;
        }
        return 1.0f;
    }
}
