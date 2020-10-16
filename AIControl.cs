using System;
using System.Collections.Generic;

namespace PokemonFightAI
{

    class AIControl
    {
        List<Attack>   rivalMoveKnowledge  = new List<Attack>();
        
        public void BuildTree(MinMaxTreeNode root)
        {
            MinMaxTreeNode mmtn = new MinMaxTreeNode(1, false, root);
            BuildTree(mmtn);
        }

        public void Think()
        {
            int max = 0;
            int[] eval = new int[4] { 0, 0, 0, 0 };
            BattleMechanics.CPU.decision = 0;
            for (int i = 0; i < 4; i++)
                if (BattleMechanics.CPU.active.chosenAttacks[i] != null)
                {
                    eval[i] = EvaluateAttackPoints(BattleMechanics.CPU.active.chosenAttacks[i]);
                    if (eval[max] < eval[i]) max = i;
                }
            BattleMechanics.CPU.activeattack = BattleMechanics.CPU.active.chosenAttacks[max];
        }

        public int EvaluateAttackPoints(PokeInstance.CAttack ca)
        {
            if(ca.curPP == 0)
                return 0;
            if(ca.a.oppHPMod < 0)
            {
                return -(ca.a.oppHPMod);
            }
            return 0;
        }

        internal class MinMaxTreeNode
        {
            int value;
            bool min;
            MinMaxTreeNode parent;
            List<MinMaxTreeNode> children = new List<MinMaxTreeNode>();

            public MinMaxTreeNode(int value, bool min, MinMaxTreeNode parent)
            {
                this.value = value;
                this.min = min;
                this.parent = parent;
                parent.children.Add(this);
            }
        }
    }
}