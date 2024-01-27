using UnityEngine;

public class RelationManager
{
    public int kingAffinity;      // If any of these drop to 0, it's game over
    public int nobillityAffinity; // If we reach 100 the levels increase
    public int mentalHealth;      //

    public int kingLevel;        // If we raise the levels, we get bonuses
    public int nobillityLevel;   //


    public void UpdateLevels()
    {
        if (kingAffinity >= 100)
        {
            kingLevel++;
            //bonuses
            if (kingLevel == 4)
            {
                GameManager.instance.PlayEnding("king_win");
            }
        }
        else if (kingAffinity <= 0)
        {
            GameManager.instance.PlayEnding("king_lose");
        }

        if (nobillityAffinity > 100)
        {
            nobillityLevel++;
            //bonuses
            if(nobillityLevel == 4)
            {
                GameManager.instance.PlayEnding("nobillity_win");
            }
        }
        else if (nobillityLevel <= 0)
        {
            GameManager.instance.PlayEnding("nobillity_lose");
        }
    }
}
