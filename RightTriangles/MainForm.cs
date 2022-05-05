using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Text;

namespace RightTriangles
{
    public partial class InputForm : Form
    {
        private RightTriangleData _currentData = new RightTriangleData();
        private IBuildModeSelector _buildModeSelector;
        private IRightTriangleValidator _validator;
        private IRightTriangleDataInput _dataInput;
        private IPropertiesInput _propertiesInput;
        private DrawerConfiguration _drawerConfig;
        private IDrawerConfigurationInput _configInput;
        private DrawingForm _drawingForm;
        public InputForm()
        {
            IBuildMode[] buildModes = new IBuildMode[]
            {
                new AdjacentLegAngleBuildMode(),
                new OppositeLegAngleBuildMode(),
                new AdjacentLegOppositeLegBuildMode(),
                new HypotenuseAngleBuildMode(),
                new HypotenuseOppositeLegBuildMode(),
                new HypotenuseAdjacentLegBuildMode()
            };
            _buildModeSelector = new BuildModeSelector(buildModes);
            _validator = new RightTriangleValidator();
            _dataInput = new RightTriangleDataInput(Controls, new Point(7, 0));
            _dataInput.AnyValueChanged += InputDataValueChanged;
            _propertiesInput = new PropertiesInput(Controls, new Point(7, _dataInput.Size.Height + 10));
            _propertiesInput.AnyValueChanged += PropertiesValueChanged;
            _drawerConfig = new DrawerConfiguration();
            _configInput = new DrawerConfigurationInput(Controls, new Point(7 + _dataInput.Size.Width + 10, 0), _drawerConfig);
            _configInput.AnyValueChanged += ConfigurationValueChanged;
            _drawingForm = new DrawingForm(new RightTriangleDrawer(_drawerConfig), _currentData, _validator);
            _drawingForm.Show();
            InitializeComponent();
            Size = PreferredSize;
            MinimizeBox = false;
            MaximizeBox = false;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Text = "Inputs";
        }

        private void ConfigurationValueChanged()
        {
            _drawerConfig = _configInput.Configuration;
            _drawingForm.Drawer.Configuration = _drawerConfig;
            _drawingForm.ChangeSize();
            _drawingForm.Refresh();
        }

        private void PropertiesValueChanged()
        {
            Properties.DecimalAccuracy = _propertiesInput.DecimalAccuracy;
            Properties.Increment = _propertiesInput.Increment;
            _dataInput.UpdateDecimalAccuracy();
            _dataInput.UpdateIncrement();
            _propertiesInput.UpdateDecimalAccuracy();
        }
        private void InputDataValueChanged()
        {
            try
            {
                _currentData = _buildModeSelector.SelectMode(_dataInput.InputData).Build(_dataInput.InputData);
                _drawingForm.Data = _currentData;
                _drawingForm.ChangeSize();
            }
            catch (ArgumentException)
            {
                // Notify user
            }
            _drawingForm.Refresh();
        }
    }
}
