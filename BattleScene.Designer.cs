namespace PokemonFightAI
{
    partial class BattleScene
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.battleFrame = new System.Windows.Forms.GroupBox();
            this.levelval = new System.Windows.Forms.Label();
            this.level = new System.Windows.Forms.Label();
            this.status = new System.Windows.Forms.PictureBox();
            this.statusCPU = new System.Windows.Forms.PictureBox();
            this.levelvalCPU = new System.Windows.Forms.Label();
            this.levelCPU = new System.Windows.Forms.Label();
            this.hpCPU = new System.Windows.Forms.Label();
            this.hpbarCPU = new System.Windows.Forms.ProgressBar();
            this.hpbar = new System.Windows.Forms.ProgressBar();
            this.brack = new System.Windows.Forms.Label();
            this.hpvalmax = new System.Windows.Forms.Label();
            this.hpval = new System.Windows.Forms.Label();
            this.hp = new System.Windows.Forms.Label();
            this.pokepic_placeholder = new System.Windows.Forms.PictureBox();
            this.pokeicon2 = new System.Windows.Forms.PictureBox();
            this.pokeicon1 = new System.Windows.Forms.PictureBox();
            this.consoleFrame = new System.Windows.Forms.GroupBox();
            this.console = new System.Windows.Forms.Label();
            this.actionFrame = new System.Windows.Forms.GroupBox();
            this.mainArrow = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.item = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.attack = new System.Windows.Forms.Label();
            this.movesFrame = new System.Windows.Forms.GroupBox();
            this.sideArrow = new System.Windows.Forms.Label();
            this.move3 = new System.Windows.Forms.Label();
            this.move2 = new System.Windows.Forms.Label();
            this.move1 = new System.Windows.Forms.Label();
            this.move0 = new System.Windows.Forms.Label();
            this.ppFrame = new System.Windows.Forms.GroupBox();
            this.typeofmove = new System.Windows.Forms.PictureBox();
            this.ppmax = new System.Windows.Forms.Label();
            this.ppleft = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.battleFrame.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.status)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusCPU)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pokepic_placeholder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pokeicon2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pokeicon1)).BeginInit();
            this.consoleFrame.SuspendLayout();
            this.actionFrame.SuspendLayout();
            this.movesFrame.SuspendLayout();
            this.ppFrame.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.typeofmove)).BeginInit();
            this.SuspendLayout();
            // 
            // battleFrame
            // 
            this.battleFrame.Controls.Add(this.levelval);
            this.battleFrame.Controls.Add(this.level);
            this.battleFrame.Controls.Add(this.status);
            this.battleFrame.Controls.Add(this.statusCPU);
            this.battleFrame.Controls.Add(this.levelvalCPU);
            this.battleFrame.Controls.Add(this.levelCPU);
            this.battleFrame.Controls.Add(this.hpCPU);
            this.battleFrame.Controls.Add(this.hpbarCPU);
            this.battleFrame.Controls.Add(this.hpbar);
            this.battleFrame.Controls.Add(this.brack);
            this.battleFrame.Controls.Add(this.hpvalmax);
            this.battleFrame.Controls.Add(this.hpval);
            this.battleFrame.Controls.Add(this.hp);
            this.battleFrame.Controls.Add(this.pokepic_placeholder);
            this.battleFrame.Controls.Add(this.pokeicon2);
            this.battleFrame.Controls.Add(this.pokeicon1);
            this.battleFrame.Location = new System.Drawing.Point(12, 12);
            this.battleFrame.Margin = new System.Windows.Forms.Padding(0);
            this.battleFrame.Name = "battleFrame";
            this.battleFrame.Size = new System.Drawing.Size(984, 517);
            this.battleFrame.TabIndex = 0;
            this.battleFrame.TabStop = false;
            this.battleFrame.Enter += new System.EventHandler(this.battleFrame_Enter);
            // 
            // levelval
            // 
            this.levelval.AutoSize = true;
            this.levelval.Location = new System.Drawing.Point(767, 450);
            this.levelval.Name = "levelval";
            this.levelval.Size = new System.Drawing.Size(89, 20);
            this.levelval.TabIndex = 15;
            this.levelval.Text = "LEVEL";
            this.levelval.Visible = false;
            // 
            // level
            // 
            this.level.AutoSize = true;
            this.level.Location = new System.Drawing.Point(672, 450);
            this.level.Name = "level";
            this.level.Size = new System.Drawing.Size(89, 20);
            this.level.TabIndex = 14;
            this.level.Text = "LEVEL";
            this.level.Visible = false;
            // 
            // status
            // 
            this.status.Location = new System.Drawing.Point(585, 424);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(80, 32);
            this.status.TabIndex = 13;
            this.status.TabStop = false;
            this.status.Visible = false;
            // 
            // statusCPU
            // 
            this.statusCPU.Location = new System.Drawing.Point(407, 53);
            this.statusCPU.Name = "statusCPU";
            this.statusCPU.Size = new System.Drawing.Size(80, 32);
            this.statusCPU.TabIndex = 12;
            this.statusCPU.TabStop = false;
            this.statusCPU.Visible = false;
            // 
            // levelvalCPU
            // 
            this.levelvalCPU.AutoSize = true;
            this.levelvalCPU.Location = new System.Drawing.Point(160, 79);
            this.levelvalCPU.Name = "levelvalCPU";
            this.levelvalCPU.Size = new System.Drawing.Size(89, 20);
            this.levelvalCPU.TabIndex = 11;
            this.levelvalCPU.Text = "LEVEL";
            this.levelvalCPU.Visible = false;
            // 
            // levelCPU
            // 
            this.levelCPU.AutoSize = true;
            this.levelCPU.Location = new System.Drawing.Point(65, 79);
            this.levelCPU.Name = "levelCPU";
            this.levelCPU.Size = new System.Drawing.Size(89, 20);
            this.levelCPU.TabIndex = 10;
            this.levelCPU.Text = "LEVEL";
            this.levelCPU.Visible = false;
            // 
            // hpCPU
            // 
            this.hpCPU.AutoSize = true;
            this.hpCPU.BackColor = System.Drawing.Color.Transparent;
            this.hpCPU.Font = new System.Drawing.Font("Pokemon Generation 1", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hpCPU.Location = new System.Drawing.Point(62, 36);
            this.hpCPU.Name = "hpCPU";
            this.hpCPU.Size = new System.Drawing.Size(81, 40);
            this.hpCPU.TabIndex = 9;
            this.hpCPU.Text = "HP";
            this.hpCPU.Visible = false;
            // 
            // hpbarCPU
            // 
            this.hpbarCPU.ForeColor = System.Drawing.Color.White;
            this.hpbarCPU.Location = new System.Drawing.Point(152, 53);
            this.hpbarCPU.Name = "hpbarCPU";
            this.hpbarCPU.Size = new System.Drawing.Size(249, 23);
            this.hpbarCPU.Step = 1;
            this.hpbarCPU.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.hpbarCPU.TabIndex = 8;
            this.hpbarCPU.Value = 100;
            this.hpbarCPU.Visible = false;
            // 
            // hpbar
            // 
            this.hpbar.ForeColor = System.Drawing.Color.White;
            this.hpbar.Location = new System.Drawing.Point(671, 424);
            this.hpbar.Name = "hpbar";
            this.hpbar.Size = new System.Drawing.Size(249, 23);
            this.hpbar.Step = 1;
            this.hpbar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.hpbar.TabIndex = 7;
            this.hpbar.Value = 100;
            this.hpbar.Visible = false;
            // 
            // brack
            // 
            this.brack.BackColor = System.Drawing.Color.Transparent;
            this.brack.Font = new System.Drawing.Font("Pokemon Generation 1", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.brack.Location = new System.Drawing.Point(766, 397);
            this.brack.Name = "brack";
            this.brack.Size = new System.Drawing.Size(28, 24);
            this.brack.TabIndex = 6;
            this.brack.Text = "/";
            this.brack.Visible = false;
            // 
            // hpvalmax
            // 
            this.hpvalmax.AutoSize = true;
            this.hpvalmax.BackColor = System.Drawing.Color.Transparent;
            this.hpvalmax.Font = new System.Drawing.Font("Pokemon Generation 1", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hpvalmax.Location = new System.Drawing.Point(800, 386);
            this.hpvalmax.Name = "hpvalmax";
            this.hpvalmax.Size = new System.Drawing.Size(81, 40);
            this.hpvalmax.TabIndex = 5;
            this.hpvalmax.Text = "HP";
            this.hpvalmax.Visible = false;
            // 
            // hpval
            // 
            this.hpval.AutoSize = true;
            this.hpval.BackColor = System.Drawing.Color.Transparent;
            this.hpval.Font = new System.Drawing.Font("Pokemon Generation 1", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hpval.Location = new System.Drawing.Point(659, 386);
            this.hpval.Name = "hpval";
            this.hpval.Size = new System.Drawing.Size(81, 40);
            this.hpval.TabIndex = 4;
            this.hpval.Text = "HP";
            this.hpval.Visible = false;
            // 
            // hp
            // 
            this.hp.AutoSize = true;
            this.hp.BackColor = System.Drawing.Color.Transparent;
            this.hp.Font = new System.Drawing.Font("Pokemon Generation 1", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hp.Location = new System.Drawing.Point(584, 386);
            this.hp.Name = "hp";
            this.hp.Size = new System.Drawing.Size(81, 40);
            this.hp.TabIndex = 3;
            this.hp.Text = "HP";
            this.hp.Visible = false;
            // 
            // pokepic_placeholder
            // 
            this.pokepic_placeholder.Image = global::PokemonFightAI.Properties.Resources.poke_empty;
            this.pokepic_placeholder.Location = new System.Drawing.Point(0, 10);
            this.pokepic_placeholder.Name = "pokepic_placeholder";
            this.pokepic_placeholder.Size = new System.Drawing.Size(32, 32);
            this.pokepic_placeholder.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pokepic_placeholder.TabIndex = 2;
            this.pokepic_placeholder.TabStop = false;
            this.pokepic_placeholder.Visible = false;
            this.pokepic_placeholder.EnabledChanged += new System.EventHandler(this.pokepic_placeholder_EnabledChanged);
            this.pokepic_placeholder.Click += new System.EventHandler(this.pokepic_placeholder_Click);
            // 
            // pokeicon2
            // 
            this.pokeicon2.BackColor = System.Drawing.Color.Transparent;
            this.pokeicon2.Location = new System.Drawing.Point(689, 24);
            this.pokeicon2.Name = "pokeicon2";
            this.pokeicon2.Size = new System.Drawing.Size(192, 192);
            this.pokeicon2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pokeicon2.TabIndex = 1;
            this.pokeicon2.TabStop = false;
            // 
            // pokeicon1
            // 
            this.pokeicon1.BackColor = System.Drawing.Color.Transparent;
            this.pokeicon1.Location = new System.Drawing.Point(113, 324);
            this.pokeicon1.Name = "pokeicon1";
            this.pokeicon1.Size = new System.Drawing.Size(192, 192);
            this.pokeicon1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pokeicon1.TabIndex = 0;
            this.pokeicon1.TabStop = false;
            // 
            // consoleFrame
            // 
            this.consoleFrame.Controls.Add(this.console);
            this.consoleFrame.Controls.Add(this.actionFrame);
            this.consoleFrame.Controls.Add(this.movesFrame);
            this.consoleFrame.Location = new System.Drawing.Point(12, 535);
            this.consoleFrame.Name = "consoleFrame";
            this.consoleFrame.Size = new System.Drawing.Size(984, 182);
            this.consoleFrame.TabIndex = 1;
            this.consoleFrame.TabStop = false;
            this.consoleFrame.Enter += new System.EventHandler(this.consoleFrame_Enter);
            // 
            // console
            // 
            this.console.BackColor = System.Drawing.Color.Transparent;
            this.console.Font = new System.Drawing.Font("Pokemon Generation 1", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.console.Location = new System.Drawing.Point(6, 17);
            this.console.Name = "console";
            this.console.Size = new System.Drawing.Size(972, 148);
            this.console.TabIndex = 4;
            this.console.Text = "CONSOLE TEXT";
            // 
            // actionFrame
            // 
            this.actionFrame.Controls.Add(this.mainArrow);
            this.actionFrame.Controls.Add(this.label2);
            this.actionFrame.Controls.Add(this.item);
            this.actionFrame.Controls.Add(this.label1);
            this.actionFrame.Controls.Add(this.attack);
            this.actionFrame.Location = new System.Drawing.Point(591, 14);
            this.actionFrame.Name = "actionFrame";
            this.actionFrame.Size = new System.Drawing.Size(387, 148);
            this.actionFrame.TabIndex = 0;
            this.actionFrame.TabStop = false;
            this.actionFrame.Text = "ACTION";
            // 
            // mainArrow
            // 
            this.mainArrow.BackColor = System.Drawing.Color.Transparent;
            this.mainArrow.Font = new System.Drawing.Font("Pokemon Generation 1", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mainArrow.Location = new System.Drawing.Point(6, 38);
            this.mainArrow.Name = "mainArrow";
            this.mainArrow.Size = new System.Drawing.Size(24, 24);
            this.mainArrow.TabIndex = 0;
            this.mainArrow.Text = ">";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Pokemon Generation 1", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(245, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 34);
            this.label2.TabIndex = 3;
            this.label2.Text = "EXIT";
            // 
            // item
            // 
            this.item.AutoSize = true;
            this.item.Font = new System.Drawing.Font("Pokemon Generation 1", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.item.Location = new System.Drawing.Point(245, 38);
            this.item.Name = "item";
            this.item.Size = new System.Drawing.Size(116, 34);
            this.item.TabIndex = 2;
            this.item.Text = "ITEM";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Pokemon Generation 1", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(26, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 34);
            this.label1.TabIndex = 1;
            this.label1.Text = "PKMN";
            // 
            // attack
            // 
            this.attack.AutoSize = true;
            this.attack.Font = new System.Drawing.Font("Pokemon Generation 1", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.attack.Location = new System.Drawing.Point(26, 38);
            this.attack.Name = "attack";
            this.attack.Size = new System.Drawing.Size(177, 34);
            this.attack.TabIndex = 0;
            this.attack.Text = "ATTACK";
            // 
            // movesFrame
            // 
            this.movesFrame.Controls.Add(this.sideArrow);
            this.movesFrame.Controls.Add(this.move3);
            this.movesFrame.Controls.Add(this.move2);
            this.movesFrame.Controls.Add(this.move1);
            this.movesFrame.Controls.Add(this.move0);
            this.movesFrame.Location = new System.Drawing.Point(24, 14);
            this.movesFrame.Name = "movesFrame";
            this.movesFrame.Size = new System.Drawing.Size(561, 148);
            this.movesFrame.TabIndex = 0;
            this.movesFrame.TabStop = false;
            this.movesFrame.Text = "MOVES";
            // 
            // sideArrow
            // 
            this.sideArrow.BackColor = System.Drawing.Color.Transparent;
            this.sideArrow.Font = new System.Drawing.Font("Pokemon Generation 1", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sideArrow.Location = new System.Drawing.Point(30, 32);
            this.sideArrow.Name = "sideArrow";
            this.sideArrow.Size = new System.Drawing.Size(24, 24);
            this.sideArrow.TabIndex = 4;
            this.sideArrow.Text = ">";
            // 
            // move3
            // 
            this.move3.Font = new System.Drawing.Font("Pokemon Generation 1", 18.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.move3.Location = new System.Drawing.Point(305, 85);
            this.move3.Name = "move3";
            this.move3.Size = new System.Drawing.Size(242, 34);
            this.move3.TabIndex = 7;
            this.move3.Text = "MOVE";
            // 
            // move2
            // 
            this.move2.Font = new System.Drawing.Font("Pokemon Generation 1", 18.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.move2.Location = new System.Drawing.Point(53, 85);
            this.move2.Name = "move2";
            this.move2.Size = new System.Drawing.Size(240, 34);
            this.move2.TabIndex = 6;
            this.move2.Text = "MOVE";
            // 
            // move1
            // 
            this.move1.Font = new System.Drawing.Font("Pokemon Generation 1", 18.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.move1.Location = new System.Drawing.Point(305, 32);
            this.move1.Name = "move1";
            this.move1.Size = new System.Drawing.Size(242, 34);
            this.move1.TabIndex = 5;
            this.move1.Text = "MOVE";
            // 
            // move0
            // 
            this.move0.Font = new System.Drawing.Font("Pokemon Generation 1", 18.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.move0.Location = new System.Drawing.Point(53, 32);
            this.move0.Name = "move0";
            this.move0.Size = new System.Drawing.Size(240, 34);
            this.move0.TabIndex = 4;
            this.move0.Text = "MOVE";
            // 
            // ppFrame
            // 
            this.ppFrame.BackColor = System.Drawing.Color.White;
            this.ppFrame.Controls.Add(this.typeofmove);
            this.ppFrame.Controls.Add(this.ppmax);
            this.ppFrame.Controls.Add(this.ppleft);
            this.ppFrame.Font = new System.Drawing.Font("Pokemon Generation 1", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ppFrame.Location = new System.Drawing.Point(12, 723);
            this.ppFrame.Name = "ppFrame";
            this.ppFrame.Size = new System.Drawing.Size(286, 44);
            this.ppFrame.TabIndex = 4;
            this.ppFrame.TabStop = false;
            this.ppFrame.Text = "MOVE INFO";
            this.ppFrame.Visible = false;
            // 
            // typeofmove
            // 
            this.typeofmove.Location = new System.Drawing.Point(210, 13);
            this.typeofmove.Name = "typeofmove";
            this.typeofmove.Size = new System.Drawing.Size(48, 25);
            this.typeofmove.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.typeofmove.TabIndex = 4;
            this.typeofmove.TabStop = false;
            // 
            // ppmax
            // 
            this.ppmax.Location = new System.Drawing.Point(149, 20);
            this.ppmax.Name = "ppmax";
            this.ppmax.Size = new System.Drawing.Size(55, 21);
            this.ppmax.TabIndex = 1;
            this.ppmax.Text = "VAL";
            // 
            // ppleft
            // 
            this.ppleft.Location = new System.Drawing.Point(88, 20);
            this.ppleft.Name = "ppleft";
            this.ppleft.Size = new System.Drawing.Size(55, 21);
            this.ppleft.TabIndex = 0;
            this.ppleft.Text = "VAL";
            // 
            // BattleScene
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1007, 773);
            this.Controls.Add(this.ppFrame);
            this.Controls.Add(this.consoleFrame);
            this.Controls.Add(this.battleFrame);
            this.Font = new System.Drawing.Font("Pokemon Generation 1", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(7, 5, 7, 5);
            this.Name = "BattleScene";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BattleScene";
            this.Load += new System.EventHandler(this.BattleScene_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.BattleScene_KeyPress);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.BattleScene_KeyUp);
            this.battleFrame.ResumeLayout(false);
            this.battleFrame.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.status)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusCPU)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pokepic_placeholder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pokeicon2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pokeicon1)).EndInit();
            this.consoleFrame.ResumeLayout(false);
            this.actionFrame.ResumeLayout(false);
            this.actionFrame.PerformLayout();
            this.movesFrame.ResumeLayout(false);
            this.ppFrame.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.typeofmove)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox battleFrame;
        private System.Windows.Forms.GroupBox consoleFrame;
        private System.Windows.Forms.GroupBox actionFrame;
        private System.Windows.Forms.Label mainArrow;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label item;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label attack;
        private System.Windows.Forms.GroupBox movesFrame;
        private System.Windows.Forms.PictureBox pokeicon2;
        private System.Windows.Forms.PictureBox pokeicon1;
        private System.Windows.Forms.PictureBox pokepic_placeholder;
        private System.Windows.Forms.Label move3;
        private System.Windows.Forms.Label move2;
        private System.Windows.Forms.Label move1;
        private System.Windows.Forms.Label move0;
        private System.Windows.Forms.Label sideArrow;
        private System.Windows.Forms.GroupBox ppFrame;
        private System.Windows.Forms.PictureBox typeofmove;
        private System.Windows.Forms.Label ppmax;
        private System.Windows.Forms.Label ppleft;
        private System.Windows.Forms.ProgressBar hpbarCPU;
        private System.Windows.Forms.ProgressBar hpbar;
        private System.Windows.Forms.Label brack;
        private System.Windows.Forms.Label hpvalmax;
        private System.Windows.Forms.Label hpval;
        private System.Windows.Forms.Label hp;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label hpCPU;
        private System.Windows.Forms.Label levelvalCPU;
        private System.Windows.Forms.Label levelCPU;
        private System.Windows.Forms.Label levelval;
        private System.Windows.Forms.Label level;
        public System.Windows.Forms.PictureBox status;
        public System.Windows.Forms.PictureBox statusCPU;
        public System.Windows.Forms.Label console;
    }
}