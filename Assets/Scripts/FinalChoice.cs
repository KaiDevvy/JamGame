using UnityEngine;
using System.Collections;
using System.Linq;

public class FinalChoice : MonoBehaviour
{
    private bool _choiceMade = false;
    private bool _isDead = false;
    public void KillBishop()
    {
        if (!OpenSecurity.fightComplete || _choiceMade)
            return;

        _isDead = true;
        EndGame();
    }
    public void EndGame()
    {
        if (!OpenSecurity.fightComplete || _choiceMade)
            return;

        _choiceMade = true;
        StartCoroutine(EndSequence());
    }

    private IEnumerator EndSequence()
    {
        if (_isDead)
        {
            yield return new WaitForSeconds(1f);
            AudioSystem.PlayOneshot("scream", 0.5f);

        }

        Destroy(DialogueSystem.current.gameObject);

        var tempList = OSManager.instance.canvas.Cast<Transform>().ToList();

        foreach (Transform child in tempList)
        {
            if (child == transform)
                continue;

            Destroy(child.gameObject);
            yield return new WaitForSeconds(0.01f);
        
        }


        float t = 0;
        while (t < 3)
        {

            t += Time.deltaTime;
            OSManager.instance.desktopBackground.color = new Color(1, (t/3), (t/3), 1);
            yield return null;
        }

    }


}