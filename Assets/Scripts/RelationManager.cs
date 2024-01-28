using UnityEngine;

public class RelationManager
{
    public int kingAffinity = 30;      // If any of these drop to 0, it's game over
    public int nobillityAffinity = 30; // If we reach 100 the levels increase
    public int mentalHealth = 30;      //

    public int kingLevel = 1;        // If we raise the levels, we get bonuses
    public int nobillityLevel = 1;   // -//-
    public int mentalLevel = 1;

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

        if (mentalHealth > 100)
        {
            mentalLevel++;
            //bonuses
            if(mentalLevel == 4)
            {
                GameManager.instance.PlayEnding("jester_win");
            }
        }
        else if (mentalLevel <= 0)
        {
            GameManager.instance.PlayEnding("jester_lose");
        }
    }
}
