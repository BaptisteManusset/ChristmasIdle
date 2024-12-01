using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu]
public class SiblingRuleTile : RuleTile
{

    public enum SiblingGroup
    {
        Environment,
        Plant,
        Other
    }
    public SiblingGroup m_siblingGroup;

    public override bool RuleMatch(int a_neighbor, TileBase a_other)
    {
        if (a_other is RuleOverrideTile)
            a_other = (a_other as RuleOverrideTile).m_InstanceTile;

        return a_neighbor switch
        {
            TilingRule.Neighbor.This => a_other is SiblingRuleTile tile &&
                                        tile.m_siblingGroup == this.m_siblingGroup,
            TilingRule.Neighbor.NotThis => !(a_other is SiblingRuleTile tile &&
                                             tile.m_siblingGroup == this.m_siblingGroup),
            _ => base.RuleMatch(a_neighbor, a_other)
        };
    }
}