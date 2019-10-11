using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

/// <summary>
/// 
/*[assembly: AssemblyVersion("1.3.2.27363")]
[assembly: CLSCompliant(true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.Default | DebuggableAttribute.DebuggingModes.DisableOptimizations | DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints | DebuggableAttribute.DebuggingModes.EnableEditAndContinue)]
[assembly: AssemblyCompany("Łukasz Świątkowski")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCopyright("Copyright © 2007-2008 Łukasz Świątkowski. All rights reserved.")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyProduct("GlassButton")]
[assembly: AssemblyTitle("GlassButtonVB")]
[assembly: AssemblyTrademark("")]
[assembly: CompilationRelaxations(8)]
//[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: ComVisible(false)]
[assembly: Guid("d9eab131-2948-46c2-907a-b875202b4cd9")]
*/
/// </summary>



namespace Joshyba.Controles
{
    [Description("Raises an event when the user clicks it."), ToolboxItem(true), ToolboxItemFilter("System.Windows.Forms"), ToolboxBitmap(typeof(Button))]
    public partial class GlassButton : Button
    {
        private class TransparentControl : Control
        {
            private static List<WeakReference> __ENCList = new List<WeakReference>();

            [DebuggerNonUserCode]
            public TransparentControl()
            {
                List<WeakReference> _ENCList = GlassButton.TransparentControl.__ENCList;
                lock (_ENCList)
                {
                    GlassButton.TransparentControl.__ENCList.Add(new WeakReference(this));
                }
            }

            protected override void OnPaintBackground(PaintEventArgs pevent)
            {
            }

            protected override void OnPaint(PaintEventArgs e)
            {
            }
        }

        private static List<WeakReference> __ENCList = new List<WeakReference>();

        private IContainer components;

        [AccessedThroughProperty("timer")]
        private Timer _timer;

        private Color _backColor;

        private Color _innerBorderColor;

        private Color _outerBorderColor;

        private Color _shineColor;

        private Color _glowColor;

        private bool _fadeOnFocus;

        private bool _isHovered;

        private bool _isFocused;

        private bool _isFocusedByKey;

        private bool _isKeyDown;

        private bool _isMouseDown;

        private EventHandler InnerBorderColorChangedEvent;

        private EventHandler OuterBorderColorChangedEvent;

        private EventHandler ShineColorChangedEvent;

        private EventHandler GlowColorChangedEvent;

        private PaintEventHandler PaintEvent;

        private Button _imageButton;

        private List<Image> _frames;

        private const int FRAME_DISABLED = 0;

        private const int FRAME_PRESSED = 1;

        private const int FRAME_NORMAL = 2;

        private const int FRAME_ANIMATED = 3;

        private const int animationLength = 300;

        private const int framesCount = 10;

        private int _currentFrame;

        private int _direction;

        [Category("Property Changed"), Description("Event raised when the value of the InnerBorderColor property is changed.")]
        public event EventHandler InnerBorderColorChanged
        {
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.Synchronized)]
            add
            {
                this.InnerBorderColorChangedEvent = (EventHandler)Delegate.Combine(this.InnerBorderColorChangedEvent, value);
            }
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.Synchronized)]
            remove
            {
                this.InnerBorderColorChangedEvent = (EventHandler)Delegate.Remove(this.InnerBorderColorChangedEvent, value);
            }
        }

        [Category("Property Changed"), Description("Event raised when the value of the OuterBorderColor property is changed.")]
        public event EventHandler OuterBorderColorChanged
        {
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.Synchronized)]
            add
            {
                this.OuterBorderColorChangedEvent = (EventHandler)Delegate.Combine(this.OuterBorderColorChangedEvent, value);
            }
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.Synchronized)]
            remove
            {
                this.OuterBorderColorChangedEvent = (EventHandler)Delegate.Remove(this.OuterBorderColorChangedEvent, value);
            }
        }

        [Category("Property Changed"), Description("Event raised when the value of the ShineColor property is changed.")]
        public event EventHandler ShineColorChanged
        {
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.Synchronized)]
            add
            {
                this.ShineColorChangedEvent = (EventHandler)Delegate.Combine(this.ShineColorChangedEvent, value);
            }
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.Synchronized)]
            remove
            {
                this.ShineColorChangedEvent = (EventHandler)Delegate.Remove(this.ShineColorChangedEvent, value);
            }
        }

        [Category("Property Changed"), Description("Event raised when the value of the GlowColor property is changed.")]
        public event EventHandler GlowColorChanged
        {
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.Synchronized)]
            add
            {
                this.GlowColorChangedEvent = (EventHandler)Delegate.Combine(this.GlowColorChangedEvent, value);
            }
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.Synchronized)]
            remove
            {
                this.GlowColorChangedEvent = (EventHandler)Delegate.Remove(this.GlowColorChangedEvent, value);
            }
        }

        public new event PaintEventHandler Paint
        {
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.Synchronized)]
            add
            {
                this.PaintEvent = (PaintEventHandler)Delegate.Combine(this.PaintEvent, value);
            }
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.Synchronized)]
            remove
            {
                this.PaintEvent = (PaintEventHandler)Delegate.Remove(this.PaintEvent, value);
            }
        }

        internal virtual Timer timer
        {
            [DebuggerNonUserCode]
            get
            {
                return this._timer;
            }
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler value2 = new EventHandler(this.timer_Tick);
                bool flag = this._timer != null;
                if (flag)
                {
                    this._timer.Tick -= value2;
                }
                this._timer = value;
                flag = (this._timer != null);
                if (flag)
                {
                    this._timer.Tick += value2;
                }
            }
        }

        [DefaultValue(typeof(Color), "Black")]
        public new virtual Color BackColor
        {
            get
            {
                return this._backColor;
            }
            set
            {
                bool flag = !this._backColor.Equals(value);
                if (flag)
                {
                    this._backColor = value;
                    this.UseVisualStyleBackColor = false;
                    this.CreateFrames();
                    this.OnBackColorChanged(EventArgs.Empty);
                }
            }
        }

        [DefaultValue(typeof(Color), "White")]
        public new virtual Color ForeColor
        {
            get
            {
                return base.ForeColor;
            }
            set
            {
                base.ForeColor = value;
            }
        }

        [Category("Appearance"), DefaultValue(typeof(Color), "Black"), Description("The inner border color of the control.")]
        public virtual Color InnerBorderColor
        {
            get
            {
                return this._innerBorderColor;
            }
            set
            {
                bool flag = this._innerBorderColor != value;
                if (flag)
                {
                    this._innerBorderColor = value;
                    this.CreateFrames();
                    flag = this.IsHandleCreated;
                    if (flag)
                    {
                        this.Invalidate();
                    }
                    this.OnInnerBorderColorChanged(EventArgs.Empty);
                }
            }
        }

        [Category("Appearance"), DefaultValue(typeof(Color), "White"), Description("The outer border color of the control.")]
        public virtual Color OuterBorderColor
        {
            get
            {
                return this._outerBorderColor;
            }
            set
            {
                bool flag = this._outerBorderColor != value;
                if (flag)
                {
                    this._outerBorderColor = value;
                    this.CreateFrames();
                    flag = this.IsHandleCreated;
                    if (flag)
                    {
                        this.Invalidate();
                    }
                    this.OnOuterBorderColorChanged(EventArgs.Empty);
                }
            }
        }

        [Category("Appearance"), DefaultValue(typeof(Color), "White"), Description("The shine color of the control.")]
        public virtual Color ShineColor
        {
            get
            {
                return this._shineColor;
            }
            set
            {
                bool flag = this._shineColor != value;
                if (flag)
                {
                    this._shineColor = value;
                    this.CreateFrames();
                    flag = this.IsHandleCreated;
                    if (flag)
                    {
                        this.Invalidate();
                    }
                    this.OnShineColorChanged(EventArgs.Empty);
                }
            }
        }

        [Category("Appearance"), DefaultValue(typeof(Color), "255,141,189,255"), Description("The glow color of the control.")]
        public virtual Color GlowColor
        {
            get
            {
                return this._glowColor;
            }
            set
            {
                bool flag = this._glowColor != value;
                if (flag)
                {
                    this._glowColor = value;
                    this.CreateFrames();
                    flag = this.IsHandleCreated;
                    if (flag)
                    {
                        this.Invalidate();
                    }
                    this.OnGlowColorChanged(EventArgs.Empty);
                }
            }
        }

        [Category("Appearance"), DefaultValue(false), Description("Indicates whether the button should fade in and fade out when it is getting and loosing the focus.")]
        public virtual bool FadeOnFocus
        {
            get
            {
                return this._fadeOnFocus;
            }
            set
            {
                bool flag = this._fadeOnFocus != value;
                if (flag)
                {
                    this._fadeOnFocus = value;
                }
            }
        }

        private bool IsPressed
        {
            get
            {
                return this._isKeyDown || (this._isMouseDown && this._isHovered);
            }
        }

        [Browsable(false)]
        public PushButtonState State
        {
            get
            {
                bool flag = !this.Enabled;
                PushButtonState result;
                if (flag)
                {
                    result = PushButtonState.Disabled;
                }
                else
                {
                    flag = this.IsPressed;
                    if (flag)
                    {
                        result = PushButtonState.Pressed;
                    }
                    else
                    {
                        flag = this._isHovered;
                        if (flag)
                        {
                            result = PushButtonState.Hot;
                        }
                        else
                        {
                            flag = (this._isFocused || this.IsDefault);
                            if (flag)
                            {
                                result = PushButtonState.Default;
                            }
                            else
                            {
                                result = PushButtonState.Normal;
                            }
                        }
                    }
                }
                return result;
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), EditorBrowsable(EditorBrowsableState.Never)]
        public new FlatButtonAppearance FlatAppearance
        {
            get
            {
                return base.FlatAppearance;
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), EditorBrowsable(EditorBrowsableState.Never)]
        public new FlatStyle FlatStyle
        {
            get
            {
                return base.FlatStyle;
            }
            set
            {
                base.FlatStyle = value;
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), EditorBrowsable(EditorBrowsableState.Never)]
        public new bool UseVisualStyleBackColor
        {
            get
            {
                return base.UseVisualStyleBackColor;
            }
            set
            {
                base.UseVisualStyleBackColor = value;
            }
        }

        private bool HasAnimationFrames
        {
            get
            {
                return this._frames != null && this._frames.Count > 3;
            }
        }

        private bool IsAnimating
        {
            get
            {
                return this._direction != 0;
            }
        }

        [DebuggerNonUserCode]
        protected override void Dispose(bool disposing)
        {
            try
            {
                if (disposing)
                {
                    bool flag = this._imageButton != null;
                    if (flag)
                    {
                        this._imageButton.Parent.Dispose();
                        this._imageButton.Parent = null;
                        this._imageButton.Dispose();
                        this._imageButton = null;
                    }
                    this.DestroyFrames();
                    flag = (this.components != null);
                    if (flag)
                    {
                        this.components.Dispose();
                    }
                }
            }
            finally
            {
                base.Dispose(disposing);
            }
        }

        [DebuggerStepThrough]
        private void InitializeComponent()
        {
            this.components = new Container();
            this.timer = new Timer(this.components);
        }

        public GlassButton()
        {
            List<WeakReference> _ENCList = GlassButton.__ENCList;
            lock (_ENCList)
            {
                GlassButton.__ENCList.Add(new WeakReference(this));
            }
            this.InitializeComponent();
            this.timer.Interval = 30;
            base.BackColor = Color.Transparent;
            this.BackColor = Color.Black;
            this.ForeColor = Color.White;
            this.OuterBorderColor = Color.White;
            this.InnerBorderColor = Color.Black;
            this.ShineColor = Color.White;
            this.GlowColor = Color.FromArgb(-7488001);
            this.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.Opaque, false);
        }

        protected virtual void OnInnerBorderColorChanged(EventArgs e)
        {
            EventHandler innerBorderColorChangedEvent = this.InnerBorderColorChangedEvent;
            bool flag = innerBorderColorChangedEvent != null;
            if (flag)
            {
                innerBorderColorChangedEvent(this, e);
            }
        }

        protected virtual void OnOuterBorderColorChanged(EventArgs e)
        {
            EventHandler outerBorderColorChangedEvent = this.OuterBorderColorChangedEvent;
            bool flag = outerBorderColorChangedEvent != null;
            if (flag)
            {
                outerBorderColorChangedEvent(this, e);
            }
        }

        protected virtual void OnShineColorChanged(EventArgs e)
        {
            EventHandler shineColorChangedEvent = this.ShineColorChangedEvent;
            bool flag = shineColorChangedEvent != null;
            if (flag)
            {
                shineColorChangedEvent(this, e);
            }
        }

        protected virtual void OnGlowColorChanged(EventArgs e)
        {
            EventHandler glowColorChangedEvent = this.GlowColorChangedEvent;
            bool flag = glowColorChangedEvent != null;
            if (flag)
            {
                glowColorChangedEvent(this, e);
            }
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            this.CreateFrames();
            base.OnSizeChanged(e);
        }

        protected override void OnClick(EventArgs e)
        {
            this._isKeyDown = false;
            this._isMouseDown = false;
            base.OnClick(e);
        }

        protected override void OnEnter(EventArgs e)
        {
            this._isFocused = true;
            this._isFocusedByKey = true;
            base.OnEnter(e);
            bool fadeOnFocus = this._fadeOnFocus;
            if (fadeOnFocus)
            {
                this.FadeIn();
            }
        }

        protected override void OnLeave(EventArgs e)
        {
            base.OnLeave(e);
            this._isFocused = false;
            this._isFocusedByKey = false;
            this._isKeyDown = false;
            this._isMouseDown = false;
            this.Invalidate();
            bool fadeOnFocus = this._fadeOnFocus;
            if (fadeOnFocus)
            {
                this.FadeOut();
            }
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            bool flag = e.KeyCode == Keys.Space;
            if (flag)
            {
                this._isKeyDown = true;
                this.Invalidate();
            }
            base.OnKeyDown(e);
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            bool flag = this._isKeyDown && e.KeyCode == Keys.Space;
            if (flag)
            {
                this._isKeyDown = false;
                this.Invalidate();
            }
            base.OnKeyUp(e);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            bool flag = !this._isMouseDown && e.Button == MouseButtons.Left;
            if (flag)
            {
                this._isMouseDown = true;
                this._isFocusedByKey = false;
                this.Invalidate();
            }
            base.OnMouseDown(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            bool isMouseDown = this._isMouseDown;
            if (isMouseDown)
            {
                this._isMouseDown = false;
                this.Invalidate();
            }
            base.OnMouseUp(e);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            bool flag = e.Button != MouseButtons.None;
            if (flag)
            {
                bool flag2 = !this.ClientRectangle.Contains(e.X, e.Y);
                if (flag2)
                {
                    bool flag3 = this._isHovered;
                    if (flag3)
                    {
                        this._isHovered = false;
                        this.Invalidate();
                    }
                }
                else
                {
                    bool flag3 = !this._isHovered;
                    if (flag3)
                    {
                        this._isHovered = true;
                        this.Invalidate();
                    }
                }
            }
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            this._isHovered = true;
            this.FadeIn();
            this.Invalidate();
            base.OnMouseEnter(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            this._isHovered = false;
            bool flag = !this.FadeOnFocus || !this._isFocusedByKey;
            if (flag)
            {
                this.FadeOut();
            }
            this.Invalidate();
            base.OnMouseLeave(e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            this.DrawButtonBackgroundFromBuffer(e.Graphics);
            this.DrawForegroundFromButton(e);
            this.DrawButtonForeground(e.Graphics);
            PaintEventHandler paintEvent = this.PaintEvent;
            bool flag = paintEvent != null;
            if (flag)
            {
                paintEvent(this, e);
            }
        }

        private void DrawButtonBackgroundFromBuffer(Graphics graphics)
        {
            bool flag = !this.Enabled;
            int index;
            if (flag)
            {
                index = 0;
            }
            else
            {
                flag = this.IsPressed;
                if (flag)
                {
                    index = 1;
                }
                else
                {
                    flag = (!this.IsAnimating && this._currentFrame == 0);
                    if (flag)
                    {
                        index = 2;
                    }
                    else
                    {
                        flag = !this.HasAnimationFrames;
                        if (flag)
                        {
                            this.CreateFrames(true);
                        }
                        index = checked(3 + this._currentFrame);
                    }
                }
            }
            flag = (this._frames == null || this._frames.Count == 0);
            if (flag)
            {
                this.CreateFrames();
            }
            graphics.DrawImage(this._frames[index], Point.Empty);
        }

        private Image CreateBackgroundFrame(bool pressed, bool hovered, bool animating, bool enabled, float glowOpacity)
        {
            Rectangle clientRectangle = this.ClientRectangle;
            bool flag = clientRectangle.Width <= 0;
            if (flag)
            {
                clientRectangle.Width = 1;
            }
            flag = (clientRectangle.Height <= 0);
            if (flag)
            {
                clientRectangle.Height = 1;
            }
            Image image = new Bitmap(clientRectangle.Width, clientRectangle.Height);
            Graphics graphics = Graphics.FromImage(image);
            try
            {
                graphics.Clear(Color.Transparent);
                GlassButton.DrawButtonBackground(graphics, clientRectangle, pressed, hovered, animating, enabled, this._outerBorderColor, this._backColor, this._glowColor, this._shineColor, this._innerBorderColor, glowOpacity);
            }
            finally
            {
                flag = (graphics != null);
                if (flag)
                {
                    ((IDisposable)graphics).Dispose();
                }
            }
            return image;
        }

        private static void DrawButtonBackground(Graphics g, Rectangle rectangle, bool pressed, bool hovered, bool animating, bool enabled, Color outerBorderColor, Color backColor, Color glowColor, Color shineColor, Color innerBorderColor, float glowOpacity)
        {
            SmoothingMode smoothingMode = g.SmoothingMode;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            Rectangle rectangle2 = rectangle;
            bool flag;
            Rectangle rectangle3;
            checked
            {
                rectangle2.Width--;
                rectangle2.Height--;
                GraphicsPath graphicsPath = GlassButton.CreateRoundRectangle(rectangle2, 4);
                try
                {
                    Pen pen = new Pen(outerBorderColor);
                    try
                    {
                        g.DrawPath(pen, graphicsPath);
                    }
                    finally
                    {
                        flag = (pen != null);
                        if (flag)
                        {
                            ((IDisposable)pen).Dispose();
                        }
                    }
                }
                finally
                {
                    flag = (graphicsPath != null);
                    if (flag)
                    {
                        ((IDisposable)graphicsPath).Dispose();
                    }
                }
                rectangle2.X++;
                rectangle2.Y++;
                rectangle2.Width -= 2;
                rectangle2.Height -= 2;
                rectangle3 = rectangle2;
                rectangle3.Height >>= 1;
                GraphicsPath graphicsPath2 = GlassButton.CreateRoundRectangle(rectangle2, 2);
                try
                {
                    int alpha = GlassButton.If<int>(pressed, 204, 127);
                    Brush brush = new SolidBrush(Color.FromArgb(alpha, backColor));
                    try
                    {
                        g.FillPath(brush, graphicsPath2);
                    }
                    finally
                    {
                        flag = (brush != null);
                        if (flag)
                        {
                            ((IDisposable)brush).Dispose();
                        }
                    }
                }
                finally
                {
                    flag = (graphicsPath2 != null);
                    if (flag)
                    {
                        ((IDisposable)graphicsPath2).Dispose();
                    }
                }
                flag = ((hovered || animating) && !pressed);
            }
            if (flag)
            {
                GraphicsPath graphicsPath3 = GlassButton.CreateRoundRectangle(rectangle2, 2);
                try
                {
                    g.SetClip(graphicsPath3, CombineMode.Intersect);
                    GraphicsPath graphicsPath4 = GlassButton.CreateBottomRadialPath(rectangle2);
                    try
                    {
                        PathGradientBrush pathGradientBrush = new PathGradientBrush(graphicsPath4);
                        try
                        {
                            int alpha2 = Convert.ToInt32(178f * glowOpacity + 0.5f);
                            RectangleF bounds = graphicsPath4.GetBounds();
                            PathGradientBrush arg_1E0_0 = pathGradientBrush;
                            PointF centerPoint = new PointF((bounds.Left + bounds.Right) / 2f, (bounds.Top + bounds.Bottom) / 2f);
                            arg_1E0_0.CenterPoint = centerPoint;
                            pathGradientBrush.CenterColor = Color.FromArgb(alpha2, glowColor);
                            pathGradientBrush.SurroundColors = new Color[]
                            {
                                Color.FromArgb(0, glowColor)
                            };
                            g.FillPath(pathGradientBrush, graphicsPath4);
                        }
                        finally
                        {
                            flag = (pathGradientBrush != null);
                            if (flag)
                            {
                                ((IDisposable)pathGradientBrush).Dispose();
                            }
                        }
                    }
                    finally
                    {
                        flag = (graphicsPath4 != null);
                        if (flag)
                        {
                            ((IDisposable)graphicsPath4).Dispose();
                        }
                    }
                    g.ResetClip();
                }
                finally
                {
                    flag = (graphicsPath3 != null);
                    if (flag)
                    {
                        ((IDisposable)graphicsPath3).Dispose();
                    }
                }
            }
            flag = (rectangle3.Width > 0 && rectangle3.Height > 0);
            checked
            {
                if (flag)
                {
                    rectangle3.Height++;
                    GraphicsPath graphicsPath5 = GlassButton.CreateTopRoundRectangle(rectangle3, 2);
                    try
                    {
                        rectangle3.Height++;
                        int num = 153;
                        flag = (pressed | !enabled);
                        if (flag)
                        {
                            num = Convert.ToInt32(unchecked(0.4f * (float)num + 0.5f));
                        }
                        LinearGradientBrush linearGradientBrush = new LinearGradientBrush(rectangle3, Color.FromArgb(num, shineColor), Color.FromArgb(num / 3, shineColor), LinearGradientMode.Vertical);
                        try
                        {
                            g.FillPath(linearGradientBrush, graphicsPath5);
                        }
                        finally
                        {
                            flag = (linearGradientBrush != null);
                            if (flag)
                            {
                                ((IDisposable)linearGradientBrush).Dispose();
                            }
                        }
                    }
                    finally
                    {
                        flag = (graphicsPath5 != null);
                        if (flag)
                        {
                            ((IDisposable)graphicsPath5).Dispose();
                        }
                    }
                    rectangle3.Height -= 2;
                }
                GraphicsPath graphicsPath6 = GlassButton.CreateRoundRectangle(rectangle2, 3);
                try
                {
                    Pen pen2 = new Pen(innerBorderColor);
                    try
                    {
                        g.DrawPath(pen2, graphicsPath6);
                    }
                    finally
                    {
                        flag = (pen2 != null);
                        if (flag)
                        {
                            ((IDisposable)pen2).Dispose();
                        }
                    }
                }
                finally
                {
                    flag = (graphicsPath6 != null);
                    if (flag)
                    {
                        ((IDisposable)graphicsPath6).Dispose();
                    }
                }
                g.SmoothingMode = smoothingMode;
            }
        }

        private void DrawButtonForeground(Graphics g)
        {
            bool flag = this.Focused && this.ShowFocusCues;
            if (flag)
            {
                Rectangle clientRectangle = this.ClientRectangle;
                clientRectangle.Inflate(-4, -4);
                ControlPaint.DrawFocusRectangle(g, clientRectangle);
            }
        }

        private void DrawForegroundFromButton(PaintEventArgs pevent)
        {
            bool flag = this._imageButton == null;
            if (flag)
            {
                this._imageButton = new Button();
                this._imageButton.Parent = new GlassButton.TransparentControl();
                this._imageButton.SuspendLayout();
                this._imageButton.BackColor = Color.Transparent;
                this._imageButton.FlatAppearance.BorderSize = 0;
                this._imageButton.FlatStyle = FlatStyle.Flat;
            }
            else
            {
                this._imageButton.SuspendLayout();
            }
            this._imageButton.AutoEllipsis = this.AutoEllipsis;
            flag = this.Enabled;
            if (flag)
            {
                this._imageButton.ForeColor = this.ForeColor;
            }
            else
            {
                this._imageButton.ForeColor = checked(Color.FromArgb(3 * this.ForeColor.R + this._backColor.R >> 2, 3 * this.ForeColor.G + this._backColor.G >> 2, 3 * this.ForeColor.B + this._backColor.B >> 2));
            }
            this._imageButton.Font = this.Font;
            this._imageButton.RightToLeft = this.RightToLeft;
            this._imageButton.Image = this.Image;
            flag = (this.Image != null && !this.Enabled);
            if (flag)
            {
                Size size = this.Image.Size;
                float[][] array = new float[5][];
                array[0] = new float[]
                {
                    0.2125f,
                    0.2125f,
                    0.2125f,
                    0f,
                    0f
                };
                array[1] = new float[]
                {
                    0.2577f,
                    0.2577f,
                    0.2577f,
                    0f,
                    0f
                };
                array[2] = new float[]
                {
                    0.0361f,
                    0.0361f,
                    0.0361f,
                    0f,
                    0f
                };
                float[] array2 = new float[5];
                array2[3] = 1f;
                array[3] = array2;
                array[4] = new float[]
                {
                    0.38f,
                    0.38f,
                    0.38f,
                    0f,
                    1f
                };
                ColorMatrix colorMatrix = new ColorMatrix(array);
                ImageAttributes imageAttributes = new ImageAttributes();
                imageAttributes.ClearColorKey();
                imageAttributes.SetColorMatrix(colorMatrix);
                this._imageButton.Image = new Bitmap(this.Image.Width, this.Image.Height);
                Graphics graphics = Graphics.FromImage(this._imageButton.Image);
                try
                {
                    Graphics arg_30C_0 = graphics;
                    Image arg_30C_1 = this.Image;
                    Rectangle destRect = new Rectangle(0, 0, size.Width, size.Height);
                    arg_30C_0.DrawImage(arg_30C_1, destRect, 0, 0, size.Width, size.Height, GraphicsUnit.Pixel, imageAttributes);
                }
                finally
                {
                    flag = (graphics != null);
                    if (flag)
                    {
                        ((IDisposable)graphics).Dispose();
                    }
                }
            }
            this._imageButton.ImageAlign = this.ImageAlign;
            this._imageButton.ImageIndex = this.ImageIndex;
            this._imageButton.ImageKey = this.ImageKey;
            this._imageButton.ImageList = this.ImageList;
            this._imageButton.Padding = this.Padding;
            this._imageButton.Size = this.Size;
            this._imageButton.Text = this.Text;
            this._imageButton.TextAlign = this.TextAlign;
            this._imageButton.TextImageRelation = this.TextImageRelation;
            this._imageButton.UseCompatibleTextRendering = this.UseCompatibleTextRendering;
            this._imageButton.UseMnemonic = this.UseMnemonic;
            this._imageButton.ResumeLayout();
            this.InvokePaint(this._imageButton, pevent);
            flag = (this._imageButton.Image != null && this._imageButton.Image != this.Image);
            if (flag)
            {
                this._imageButton.Image.Dispose();
                this._imageButton.Image = null;
            }
        }

        private static GraphicsPath CreateRoundRectangle(Rectangle rectangle, int radius)
        {
            GraphicsPath graphicsPath = new GraphicsPath();
            int left = rectangle.Left;
            int top = rectangle.Top;
            int width = rectangle.Width;
            int height = rectangle.Height;
            int num = radius << 1;
            graphicsPath.AddArc(left, top, num, num, 180f, 90f);
            checked
            {
                graphicsPath.AddLine(left + radius, top, left + width - radius, top);
                graphicsPath.AddArc(left + width - num, top, num, num, 270f, 90f);
                graphicsPath.AddLine(left + width, top + radius, left + width, top + height - radius);
                graphicsPath.AddArc(left + width - num, top + height - num, num, num, 0f, 90f);
                graphicsPath.AddLine(left + width - radius, top + height, left + radius, top + height);
                graphicsPath.AddArc(left, top + height - num, num, num, 90f, 90f);
                graphicsPath.AddLine(left, top + height - radius, left, top + radius);
                graphicsPath.CloseFigure();
                return graphicsPath;
            }
        }

        private static GraphicsPath CreateTopRoundRectangle(Rectangle rectangle, int radius)
        {
            GraphicsPath graphicsPath = new GraphicsPath();
            int left = rectangle.Left;
            int top = rectangle.Top;
            int width = rectangle.Width;
            int height = rectangle.Height;
            int num = radius << 1;
            graphicsPath.AddArc(left, top, num, num, 180f, 90f);
            checked
            {
                graphicsPath.AddLine(left + radius, top, left + width - radius, top);
                graphicsPath.AddArc(left + width - num, top, num, num, 270f, 90f);
                graphicsPath.AddLine(left + width, top + radius, left + width, top + height);
                graphicsPath.AddLine(left + width, top + height, left, top + height);
                graphicsPath.AddLine(left, top + height, left, top + radius);
                graphicsPath.CloseFigure();
                return graphicsPath;
            }
        }

        private static GraphicsPath CreateBottomRadialPath(Rectangle rectangle)
        {
            GraphicsPath graphicsPath = new GraphicsPath();
            RectangleF rect = rectangle;
            rect.X -= rect.Width * 0.35f;
            rect.Y -= rect.Height * 0.15f;
            rect.Width *= 1.7f;
            rect.Height *= 2.3f;
            graphicsPath.AddEllipse(rect);
            graphicsPath.CloseFigure();
            return graphicsPath;
        }

        private void CreateFrames()
        {
            this.CreateFrames(false);
        }

        private void CreateFrames(bool withAnimationFrames)
        {
            this.DestroyFrames();
            bool flag = !this.IsHandleCreated;
            checked
            {
                if (!flag)
                {
                    flag = (this._frames == null);
                    if (flag)
                    {
                        this._frames = new List<Image>();
                    }
                    this._frames.Add(this.CreateBackgroundFrame(false, false, false, false, 0f));
                    this._frames.Add(this.CreateBackgroundFrame(true, true, false, true, 0f));
                    this._frames.Add(this.CreateBackgroundFrame(false, false, false, true, 0f));
                    flag = !withAnimationFrames;
                    if (!flag)
                    {
                        int num = 0;
                        int arg_C0_0;
                        int num2;
                        do
                        {
                            this._frames.Add(this.CreateBackgroundFrame(false, true, true, true, Convert.ToSingle(num) / 9f));
                            num++;
                            arg_C0_0 = num;
                            num2 = 9;
                        }
                        while (arg_C0_0 <= num2);
                    }
                }
            }
        }

        private void DestroyFrames()
        {
            bool flag = this._frames != null;
            checked
            {
                if (flag)
                {
                    while (this._frames.Count > 0)
                    {
                        this._frames[this._frames.Count - 1].Dispose();
                        this._frames.RemoveAt(this._frames.Count - 1);
                    }
                }
            }
        }

        private void FadeIn()
        {
            this._direction = 1;
            this.timer.Enabled = true;
        }

        private void FadeOut()
        {
            this._direction = -1;
            this.timer.Enabled = true;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            bool flag = !this.timer.Enabled;
            checked
            {
                if (!flag)
                {
                    this.Refresh();
                    this._currentFrame += this._direction;
                    flag = (this._currentFrame == -1);
                    if (flag)
                    {
                        this._currentFrame = 0;
                        this.timer.Enabled = false;
                        this._direction = 0;
                    }
                    else
                    {
                        flag = (this._currentFrame == 10);
                        if (flag)
                        {
                            this._currentFrame = 9;
                            this.timer.Enabled = false;
                            this._direction = 0;
                        }
                    }
                }
            }
        }

        private static T If<T>(bool condition, T obj1, T obj2)
        {
            T result;
            if (condition)
            {
                result = obj1;
            }
            else
            {
                result = obj2;
            }
            return result;
        }
    }
}
