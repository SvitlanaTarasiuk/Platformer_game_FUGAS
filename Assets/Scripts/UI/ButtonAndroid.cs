using UnityEngine;

public class ButtonAndroid : MonoBehaviour
{
    private Hero hero;

    void Start()
    {
        hero = SingletoneHero._singletoneHero.GetComponent<Hero>();
    }

    public void LeftRunDown()
    {
        hero.move = -1;
    }
    public void LefthRunUp()
    {
        hero.move = 0;
    }
    public void RigthRunDown()
    {
        hero.move = 1;
    }
    public void RigthRunUp()
    {
        hero.move = 0;
    }
    public void JumpClick() //Down
    {
        hero.JumpMobile();
    }
    public void AttackClick() //Down
    {
        hero.AttackMomile();
    }
    
}
