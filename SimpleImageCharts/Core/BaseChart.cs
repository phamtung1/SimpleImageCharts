using System.Drawing;
using System.Linq;
using GdiSharp.Components;
using GdiSharp.Components.Base;
using GdiSharp.Models;
using GdiSharp.Renderer;
using SimpleImageCharts.Core.GdiChartComponents;
using SimpleImageCharts.Core.Models;

namespace SimpleImageCharts.Core
{
    public abstract class BaseChart : IBaseChart
    {
        public Size Size { get; set; }

        public Padding Padding { get; set; } = new Padding(30);

        public SubTitleModel SubTitle { get; set; }

        public LegendModel Legend { get; set; }

        public SlimFont Font { get; set; } = SlimFont.Default;

        private GdiContainer MainContainer { get; set; }

        private GdiRectangle ChartContainer { get; set; }

        public IImageFile CreateImage()
        {
            this.SetupContainer();
            this.Init(MainContainer, ChartContainer);
            this.BuildComponents(MainContainer, ChartContainer);
            var bitmap = new Bitmap(Size.Width, Size.Height);
            var renderer = new GdiRenderer(bitmap);
            renderer.Render(MainContainer);
            using (var graphics = renderer.GetGraphics())
            {
                this.Draw(graphics);
            }

            return new ImageFile(bitmap);
        }

        private void SetupContainer()
        {
            MainContainer = new GdiRectangle
            {
                Size = this.Size,
                Color = Color.White
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
        }

        protected virtual void Draw(Graphics graphics)
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
                Color = SubTitle.Color,
                HorizontalAlignment = GdiSharp.Enum.GdiHorizontalAlign.Center,
                VerticalAlignment = GdiSharp.Enum.GdiVerticalAlign.Bottom,
                Margin = new PointF(0, 10),
                Font = new SlimFont(SubTitle.FontName, SubTitle.FontSize, FontStyle.Bold)
            };
            mainContainer.AddChild(gdiText);
        }

        protected virtual void AddLegend(GdiContainer mainContainer)
        {
            if (Legend == null || Legend.Items == null || !Legend.Items.Any())
            {
                return;
            }

            mainContainer.AddChild(new GdiLegend
            {
                Legend = Legend
            });
        }
    }
}