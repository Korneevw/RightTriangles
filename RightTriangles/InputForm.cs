using System.Drawing;
using System;
using System.Windows.Forms;

namespace RightTriangles
{
    public partial class InputForm : Form
    {
        private RightTriangleData _currentData = new RightTriangleData();
        private IRightTriangleBuildModeSelector _buildModeSelector;
        private IRightTriangleValidator _validator;
        private IRightTriangleDataInput _dataInput;
        private IPropertiesInput _propertiesInput;
        private DrawerConfiguration _drawerConfig;
        private IDrawerConfigurationInput _configInput;
        private DrawingForm _drawingForm;
        private IRightTriangleAdditionalDataGetter _additionalDataGetter;
        private RightTriangleAdditionalData _currentAdditionalData = new RightTriangleAdditionalData();
        private IAdditionalDataDisplayer _additionalDataDisplayer;
        public InputForm()
        {
            IRightTriangleBuildMode[] buildModes = new IRightTriangleBuildMode[]
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
            _dataInput.ResetButtonClick += ResetButtonClick;
            _propertiesInput = new PropertiesInput(Controls, new Point(7, _dataInput.Size.Height + 10));
            _propertiesInput.AnyValueChanged += PropertiesValueChanged;
            _drawerConfig = new DrawerConfiguration();
            _configInput = new DrawerConfigurationInput(Controls, new Point(7 + _dataInput.Size.Width + 10, 0), _drawerConfig);
            _configInput.AnyValueChanged += ConfigurationValueChanged;
            _drawingForm = new DrawingForm(new RightTriangleDrawer(_drawerConfig), _currentData, _validator, new DrawingSaver());
            _drawingForm.Show();
            _additionalDataGetter = new AdditionalDataGetter(new RightTriangleValidator());
            _additionalDataDisplayer = new AdditionalDataDisplayer(Controls, new Point(7, _dataInput.Size.Height + 10 + _propertiesInput.Size.Height), _drawerConfig);
            _additionalDataDisplayer.Configuration = _drawerConfig;
            _additionalDataDisplayer.CurrentAdditionalData = _currentAdditionalData;
            InitializeComponent();
            Size = PreferredSize;
            MinimizeBox = false;
            MaximizeBox = false;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Text = "Right Triangle Builder";
        }

        private void ResetButtonClick()
        {
            _currentAdditionalData = new RightTriangleAdditionalData();
            _additionalDataDisplayer.CurrentAdditionalData = _currentAdditionalData;
            _additionalDataDisplayer.UpdateLabels();
            Size = PreferredSize;
            _currentData = new RightTriangleData();
            _drawingForm.Data = _currentData;
            _drawingForm.Refresh();
            _drawingForm.ChangeSize();
        }

        private void ConfigurationValueChanged()
        {
            _drawerConfig = _configInput.Configuration;
            _drawingForm.Drawer.Configuration = _drawerConfig;
            _drawingForm.ChangeSize();
            _drawingForm.Refresh();
            _additionalDataDisplayer.Configuration = _drawerConfig;
            if (_currentAdditionalData is not null) _additionalDataDisplayer.UpdateLabels();
            Size = PreferredSize;
        }

        private void PropertiesValueChanged()
        {
            Properties.DecimalAccuracy = _propertiesInput.DecimalAccuracy;
            Properties.Increment = _propertiesInput.Increment;
            _dataInput.UpdateDecimalAccuracy();
            _dataInput.UpdateIncrement();
            _propertiesInput.UpdateDecimalAccuracy();
            if (_currentAdditionalData is not null) _additionalDataDisplayer.UpdateLabels();
        }
        private void InputDataValueChanged()
        {
            try
            {
                _currentData = _buildModeSelector.SelectMode(_dataInput.InputData).Build(_dataInput.InputData);
                _currentAdditionalData = _additionalDataGetter.GetAdditionalData(_currentData);
                _additionalDataDisplayer.CurrentAdditionalData = _currentAdditionalData;
                _additionalDataDisplayer.UpdateLabels();
                Size = PreferredSize;
                _drawingForm.Data = _currentData;
                _drawingForm.ChangeSize();
                _drawingForm.Refresh();
            }
            catch (ArgumentException) { }
        }
    }
}
