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
        public Size Size { get; set; }

        public PaddingModel Padding { get; set; } = new PaddingModel(30);

        public SubTitleModel SubTitle { get; set; }

        public LegendModel Legend { get; set; }

        public Font Font { get; set; } = new Font("Arial", 12);

        private GdiContainer Container { get; set; }

        private GdiRectangle DataArea { get; set; }

        public IImageFile CreateImage()
        {
            this.SetupContainer();
            this.Init(Container, DataArea);
            this.BuildComponents(Container, DataArea);
            var bitmap = new Bitmap(Size.Width, Size.Height);
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
                Size = this.Size,
                Color = Color.White
            };
            DataArea = new GdiRectangle
            {
                Position = new PointF(Padding.Left, Padding.Top),
                Size = new SizeF(Size.Width - Padding.Left - Padding.Right, Size.Height - Padding.Top - Padding.Bottom)
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
                Position = new PointF(0, -10),
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