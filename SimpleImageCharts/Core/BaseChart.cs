using GdiSharp.Components;
using GdiSharp.Components.Base;
using GdiSharp.Models;
using GdiSharp.Renderer;
using SimpleImageCharts.Core.GdiChartComponents;
using SimpleImageCharts.Core.Models;
using System;
using System.Drawing;
using System.Linq;

namespace SimpleImageCharts.Core
{
    public abstract class BaseChart : IBaseChart
    {
        public Size Size { get; set; }

        public Padding Padding { get; set; } = new Padding(30);

        public SubTitleModel SubTitle { get; set; }

        public LegendModel Legend { get; set; }

        public SlimFont Font { get; set; } = SlimFont.Default;

        protected GdiContainer MainContainer { get; set; }

        protected float LegendWidth { get; set; } = 0;

        protected float LegendHeight { get; set; } = 0;

        private GdiRectangle ChartContainer { get; set; }

        public IImageFile CreateImage()
        {
            this.SetupContainer();
            this.Init(MainContainer, ChartContainer);
            this.BuildComponents(MainContainer, ChartContainer);
            var bitmap = new Bitmap(Size.Width, Size.Height);
            var renderer = new GdiRenderer(bitmap);
            using (var graphics = renderer.GetGraphics())
            {
                this.DrawBeforeRender(graphics);
                renderer.Render(MainContainer);
                this.DrawAfterRender(graphics);
            }

            return new ImageFile(bitmap);
        }

        private void SetupContainer()
        {
            MainContainer = new GdiRectangle
            {
                Size = this.Size,
                BackgroundColor = Color.White
            };
            ChartContainer = new GdiRectangle
            {
                Margin = new PointF(Padding.Left, Padding.Top),
                Size = new SizeF(Size.Width - Padding.Left - Padding.Right, Size.Height - Padding.Top - Padding.Bottom)
            };
            MainContainer.AddChild(ChartContainer);
        }

        protected virtual void Init(GdiContainer mainContainer, GdiRectangle chartContainer)
        {
        }

        protected virtual void BuildComponents(GdiContainer mainContainer, GdiRectangle chartContainer)
        {
            if (Legend != null && Legend.Items == null)
            {
                CreateLegendItems();
            }

            if (Legend != null && Legend.Items != null && Legend.Items.Any())
            {
                mainContainer.AddChild(new GdiLegend
                {
                    Margin = new PointF(this.Padding.Left, 20),
                    VerticalAlignment = GdiSharp.Enum.GdiVerticalAlign.Bottom,
                    Size = new SizeF(
                        LegendWidth == 0 ? chartContainer.Size.Width : LegendWidth, 
                        LegendHeight == 0 ? Math.Max(GdiLegendItem.LineHeight, this.Padding.Bottom - 50) : LegendHeight),
                    Legend = Legend
                });
            }
        }

        protected virtual void DrawBeforeRender(Graphics graphics)
        {
        }

        protected virtual void DrawAfterRender(Graphics graphics)
        {
        }

        protected virtual void AddSubTitle(GdiContainer mainContainer)
        {
            if (SubTitle == null || string.IsNullOrWhiteSpace(SubTitle.Text))
            {
                return;
            }

            var gdiText = new GdiText
            {
                Content = SubTitle.Text,
                BackgroundColor = SubTitle.Color,
                HorizontalAlignment = GdiSharp.Enum.GdiHorizontalAlign.Center,
                VerticalAlignment = GdiSharp.Enum.GdiVerticalAlign.Bottom,
                Margin = new PointF(0, 10),
                Font = new SlimFont(SubTitle.FontName, SubTitle.FontSize, FontStyle.Bold)
            };
            mainContainer.AddChild(gdiText);
        }

        protected virtual void CreateLegendItems()
        {
        }
    }
}