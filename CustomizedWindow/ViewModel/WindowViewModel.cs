using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CustomizedWindow
{
    /// <summary>
    /// The view model for the custom flat window
    /// </summary>
    public class WindowViewModel:BaseViewModel
    {

        #region Private members
        /// <summary>
        /// The window this view model controls
        /// </summary>
        private Window mWindow;

        /// <summary>
        /// The margin around the window to allow for a drop shadow
        /// </summary>
        private int mOuterMarginSize = 10;

        /// <summary>
        /// The radius of the edges of the window
        /// </summary>
        private int mWindowRadius = 10;
        #endregion

        #region Public properties

        /// <summary>
        /// The size of the resize border around the window
        /// </summary>
        public int ResizeBorder { get; set; } = 20;

        public Thickness ResizeBorderThickness { get { return new Thickness(ResizeBorder); } }

        

        /// <summary>
        /// The margin around the window to allow for a drop shadow.
        /// When window is maximized, margin will be zero.
        /// 
        /// </summary>
        public int OuterMarginSize
        {
            get { return mWindow.WindowState == WindowState.Maximized ? 0 : mOuterMarginSize; }
            set { mOuterMarginSize = value; }
        }

        public Thickness OuterMarginSizeThickness { get { return new Thickness(OuterMarginSize); } }

        /// <summary>
        /// The radius of the edges of the window
        /// When window is maximized, radius will be zero.
        /// </summary>
        public int WindowRadius
        {
            get { return mWindow.WindowState == WindowState.Maximized ? 0 : mWindowRadius; }
            set { mWindowRadius = value; }
        }

        /// <summary>
        /// The radius of the edges of the window
        /// When window is maximized, radius will be zero.
        /// </summary>
        public CornerRadius WindowCornerRadius { get { return new CornerRadius(WindowRadius); } }

        /// <summary>
        /// The height of the title bar
        /// </summary>
        public int TitleHeight { get; set; } = 42;

        /// <summary>
        /// The height of the title bar
        /// </summary>
        public GridLength TitleHeightGridLength { get { return new GridLength( TitleHeight ); } }


        #endregion

        #region Constructor
        /// <summary>
        /// Default constructor
        /// </summary>
        public WindowViewModel(Window window)
        {
            this.mWindow = window;

            //Listen out for the window resizing
            this.mWindow.StateChanged += (sender, e) =>
            {
                OnPropertyChanged(nameof(ResizeBorderThickness));
                OnPropertyChanged(nameof(OuterMarginSize));
                OnPropertyChanged(nameof(OuterMarginSizeThickness));
                OnPropertyChanged(nameof(WindowRadius));
                OnPropertyChanged(nameof(WindowCornerRadius));
            };
        }
        #endregion

    }
}
