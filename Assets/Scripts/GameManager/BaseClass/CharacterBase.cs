using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBase : MonoBehaviour
{
    public float currentHP; //當前生命值
    public float maxHP; //最大生命值

    public float strength; //力量, 影響力量型武器傷害及負重
    public float intelligence; //智力，影響智力型武器傷害
    public float agility; //敏捷，影響敏捷型武器傷害，閃避及移動?
    public float constitution; //體質，影響生命值
    public float wits; //智慧，影響命中率及暴擊率
    public float memory; //記憶，影響可學習技能數

    public float physicalDefense; //物防
    public float magicalDefense;//魔防

    public float luck; //幸運，影響戰利品，發現物品
}
