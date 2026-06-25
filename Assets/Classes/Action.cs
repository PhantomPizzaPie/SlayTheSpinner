using Random = UnityEngine.Random;
public class Action
{
    public ActionDetails actionDetails;
    public int luckFactor;

    public Action(ActionDetails actionDetails)
    {
        this.actionDetails = actionDetails;
        luckFactor = Random.Range(actionDetails.minLuck, actionDetails.maxLuck);
    }
}