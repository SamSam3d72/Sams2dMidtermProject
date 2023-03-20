using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public Image[] heartImages;

    private void Update()
    {
        for (int i = 0; i < heartImages.Length; i++)
        {
            if (i < playerHealth.currentHealth)
            {
                heartImages[i].enabled = true;
            }
            else
            {
                heartImages[i].enabled = false;
            }
        }
    }
}
