using System.Drawing;
using System.Linq;
using GdiSharp.Components;
using GdiSharp.Components.Base;
using GdiSharp.Renderer;
using SimpleImageCharts.Core.GdiChartComponents;
using SimpleImageCharts.Core.Models;

namespace SimpleImageCharts.Core
{
    public abstract class BaseChart : IImageChart
    {
        public int Width { get; set; } = 500;

        public int Height { get; set; } = 500;

        public int MarginRight { get; set; } = 30;

        public int MarginTop { get; set; } = 30;

        public int MarginBottom { get; set; } = 30;

        public int MarginLeft { get; set; } = 30;

        public SubTitleModel SubTitle { get; set; }

        public LegendModel Legend { get; set; }

        private GdiContainer Container { get; set; }

        private GdiRectangle DataArea { get; set; }

        public IImageFile CreateImage()
        {
            this.SetupContainer();
            this.Init(Container, DataArea);
            this.BuildComponents(Container, DataArea);
            var bitmap = new Bitmap(Width, Height);
            var renderer = new GdiRenderer(bitmap);
            renderer.Render(Container);
            using (var graphics = renderer.GetGraphics())
            {
                this.Draw(graphics);
            }

            return new ImageFile(bitmap);
        }

        private void SetupContainer()
        {
            Container = new GdiRectangle
            {
                Width = Width,
                Height = Height,
                Color = Color.White
            };
            DataArea = new GdiRectangle
            {
                Color = Color.LightCyan,
                X = MarginLeft,
                Y = MarginTop,
                Width = Width - MarginLeft - MarginRight,
                Height = Height - MarginTop - MarginBottom,
                BorderWidth = 1
            };
            Container.AddChild(DataArea);
        }

        protected virtual void Init(GdiContainer container, GdiRectangle dataArea)
        {
        }

        protected virtual void BuildComponents(GdiContainer container, GdiRectangle dataArea)
        {
        }

        protected virtual void Draw(Graphics graphics)
        {
        }

        protected virtual void AddSubTitle(GdiContainer container)
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
                Y = 10,
                Font = new Font(SubTitle.FontName, SubTitle.FontSize, FontStyle.Bold)
            };
            container.AddChild(gdiText);
        }

        protected virtual void AddLegend(GdiContainer container)
        {
            if (Legend == null || Legend.Items == null || !Legend.Items.Any())
            {
                return;
            }

            container.AddChild(new GdiLegend
            {
                Legend = Legend,
            });
        }
    }
}