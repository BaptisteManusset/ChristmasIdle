using System;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu]
public class SiblingRuleTile : RuleTile
{
    public enum SiblingGroup
    {
        Environment = 1,
        Plant = 2,
        Tree = 3,
        House = 4,
        Other = 5,
        Water = 6
    }

    [Flags]
    public enum FlagSiblingGroup
    {
        Environment = 1 << SiblingGroup.Environment,
        Plant = 1 << SiblingGroup.Plant,
        Tree = 1 << SiblingGroup.Tree,
        House = 1 << SiblingGroup.House,
        Other = 1 << SiblingGroup.Other,
        Water = 1 << SiblingGroup.Water
    }

    public SiblingGroup m_currentFlag;
    public FlagSiblingGroup m_siblingGroup;

    public override bool RuleMatch(int a_neighbor, TileBase a_other)
    {
        if (a_other is RuleOverrideTile)
            a_other = (a_other as RuleOverrideTile).m_InstanceTile;

        return a_neighbor switch
        {
            TilingRule.Neighbor.This => a_other is SiblingRuleTile tile && MustConnect(tile),
            TilingRule.Neighbor.NotThis => !(a_other is SiblingRuleTile tile && MustConnect(tile)),
            _ => base.RuleMatch(a_neighbor, a_other)
        };
    }

    private bool MustConnect(SiblingRuleTile tile)
    {
        return tile.m_siblingGroup.HasFlag((FlagSiblingGroup)(1 << (int)m_currentFlag));
    }
}