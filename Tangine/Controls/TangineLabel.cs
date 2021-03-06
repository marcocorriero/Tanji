﻿using System;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;

namespace Tangine.Controls
{
    [DesignerCategory("Code")]
    public class TangineLabel : Control
    {
        private int _borderWidth = 1;
        [DefaultValue(1)]
        public int BorderWidth
        {
            get => _borderWidth;
            set
            {
                _borderWidth = value;
                Invalidate();
            }
        }

        private bool _isBorderVisible = true;
        [DefaultValue(true)]
        public bool IsBorderVisible
        {
            get => _isBorderVisible;
            set
            {
                _isBorderVisible = value;
                Invalidate();
            }
        }

        private LabelBorderMode _borderMode = LabelBorderMode.Both;
        [DefaultValue(LabelBorderMode.Both)]
        public LabelBorderMode BorderMode
        {
            get => _borderMode;
            set
            {
                _borderMode = value;
                Invalidate();
            }
        }

        [Localizable(true)]
        [DefaultValue(typeof(Size), "150, 20")]
        public new Size Size
        {
            get => base.Size;
            set => base.Size = value;
        }

        private Color _skin = Color.FromArgb(243, 63, 63);
        [DefaultValue(typeof(Color), "243, 63, 63")]
        public Color Skin
        {
            get => _skin;
            set
            {
                _skin = value;
                Invalidate();
            }
        }

        [DefaultValue(typeof(Color), "White")]
        public override Color BackColor
        {
            get => base.BackColor;
            set => base.BackColor = value;
        }

        public override string Text
        {
            get => base.Text;
            set
            {
                base.Text = value;
                Invalidate();
            }
        }

        public TangineLabel()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.SupportsTransparentBackColor | ControlStyles.ResizeRedraw, true);
            DoubleBuffered = true;

            Height = 20;
            BackColor = Color.White;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.Clear(BackColor);
            if (IsBorderVisible)
            {
                using (var brush = new SolidBrush(Skin))
                {
                    if (BorderMode.HasFlag(LabelBorderMode.Left))
                        e.Graphics.FillRectangle(brush, 0, 0, BorderWidth, Height);

                    if (BorderMode.HasFlag(LabelBorderMode.Right))
                        e.Graphics.FillRectangle(brush, Width - BorderWidth, 0, BorderWidth, Height);
                }
            }
            TextRenderer.DrawText(e.Graphics, Text, Font, ClientRectangle, ForeColor);
            base.OnPaint(e);
        }

        [Flags]
        public enum LabelBorderMode
        {
            Left = 1,
            Right,
            Both
        }
    }
}