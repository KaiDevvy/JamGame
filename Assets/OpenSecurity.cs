using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenSecurity : Interactable
{
    public GameObject[] spawnableWindows;
    private RectTransform securityWindow;
    private BoxCollider2D securityDefenseRect;

    public static bool fightComplete = false;

    public override void ClickEnd()
    {  base.ClickEnd();

        if (!fightComplete)
            StartCoroutine(Event());
        else
        {
            int index = securityWindow.transform.parent.childCount;
            securityWindow.transform.SetSiblingIndex(index-1);
            securityWindow.transform.position = Vector3.zero;
        }

        GetComponent<BoxCollider2D>().enabled = false;
        transform.GetChild(0).gameObject.SetActive(false);
    }

    private IEnumerator Event()
    {
        OSManager.desktopIcons["Vulpe Defender"].data.locked = false;

        OSManager.desktopIcons["Vulpe Defender"].ClickEnd();
        securityWindow = OSManager.desktopIcons["Vulpe Defender"].trackedInstance.transform as RectTransform;
        securityDefenseRect = securityWindow.Find("Defense").GetComponent<BoxCollider2D>();

        yield return new WaitForSeconds(0.8f);

        OSManager.instance.desktopBackground.color = new Color(1, 0, 0, 1);


        float t = 0;
        while (t < 1)
        {

            t += Time.deltaTime;
            OSManager.instance.desktopBackground.color = new Color(1, t, t, 1);
            yield return null;
        }

        DialogueSystem.current.StartDialogue("Fight1");
        AudioSystem.PlayOneshot("boss");

        yield return FightLoop();
    }

    private IEnumerator FightLoop()
    {
        int stage = 0;
        int phase = 0;
        while (stage < 2)
        {
            switch (stage)
            {
                case 0:
                    if (securityDefenseRect.bounds.Contains(Mouse.WorldPosition))
                    {
                        securityWindow.transform.position = new Vector3(Random.Range(-10, 10), Random.Range(-8, 8));
                        phase++;
                    }

                    if (phase > 5)
                    {
                        phase = 0;

                        DialogueSystem.current.StartDialogue("Fight2");
                        stage++;
                    }
                    break;

                case 1:
                    if (securityDefenseRect.bounds.Contains(Mouse.WorldPosition))
                    {
                        securityWindow.transform.position = new Vector3(Random.Range(-10, 10), Random.Range(-8, 8));
                        if (phase % 2 == 0)
                            Instantiate(spawnableWindows[Random.Range(0, spawnableWindows.Length)], OSManager.instance.canvas).transform.position = securityWindow.transform.position;
                        
                        phase++;
                    }

                    if (phase == 5)
                    {
                        DialogueSystem.current.StartDialogue("Fight3");
                        phase++;
                    }

                    if (phase > 12)
                    {
                        phase = 0;
                        stage++;
                    }
                        break;

            }

            yield return new WaitForSeconds(0.1f);

        }


        DialogueSystem.current.StartDialogue("Fight4");

        yield return new WaitForSeconds(0.1f);

        AudioSystem.Stop();

        for (int i = 0; i < 100; i++)
        {
            Instantiate(spawnableWindows[Random.Range(0, spawnableWindows.Length)], OSManager.instance.canvas).transform.position = new Vector3(Random.Range(-10, 10), Random.Range(-8, 8));
            yield return new WaitForSeconds(0.01f);
        }

        yield return new WaitForSeconds(3f);

        DialogueSystem.current.expressionHolder.color = new Color(1, 1, 1, 0.7f);

        yield return new WaitForSeconds(2f);

        fightComplete = true;
        GetComponent<BoxCollider2D>().enabled = true;
        transform.GetChild(0).gameObject.SetActive(true);
    }
}
