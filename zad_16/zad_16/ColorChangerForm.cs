using System;
using System.Drawing;
using System.Windows.Forms;

namespace ColorChangerApp
{
    public partial class ColorChangerForm : Form
    {
        // Перечисление для цветов
        private enum AppColor
        {
            Красный,
            Зелёный,
            Синий,
            Фиолетовый,
            Оранжевый,
            Белый,
            Стандартный
        }

        // Элементы управления
        private CheckBox modeCheckBox;
        private GroupBox colorGroup;
        private Button[] colorButtons;
        private RadioButton[] colorRadioButtons;

        public ColorChangerForm()
        {
            InitializeComponent();
            InitializeCustomComponents();
        }

        private void InitializeCustomComponents()
        {
            // Инициализация CheckBox
            modeCheckBox = new CheckBox
            {
                Text = "Управление через RadioButton",
                Location = new Point(20, 20),
                AutoSize = true
            };
            modeCheckBox.CheckedChanged += ModeCheckBox_CheckedChanged;
            Controls.Add(modeCheckBox);

            // Получение названий цветов из перечисления
            string[] colors = Enum.GetNames(typeof(AppColor));
            colorButtons = new Button[colors.Length];

            // Инициализация кнопок цветов
            for (int i = 0; i < colors.Length; i++)
            {
                colorButtons[i] = new Button
                {
                    Text = colors[i],
                    Location = new Point(20, 60 + i * 40),
                    Size = new Size(120, 30),
                    Tag = Enum.Parse(typeof(AppColor), colors[i]) // Сохраняем значение enum
                };
                colorButtons[i].Click += ColorButton_Click;
                Controls.Add(colorButtons[i]);
            }

            // Инициализация GroupBox и RadioButton
            colorGroup = new GroupBox
            {
                Text = "Выбор цвета",
                Location = new Point(200, 20),
                Size = new Size(150, 250),
                Visible = false
            };
            colorRadioButtons = new RadioButton[colors.Length];
            for (int i = 0; i < colors.Length; i++)
            {
                colorRadioButtons[i] = new RadioButton
                {
                    Text = colors[i],
                    Location = new Point(10, 20 + i * 30),
                    AutoSize = true,
                    Enabled = false,
                    Tag = Enum.Parse(typeof(AppColor), colors[i]) // Сохраняем значение enum
                };
                colorRadioButtons[i].CheckedChanged += ColorRadioButton_CheckedChanged;
                colorGroup.Controls.Add(colorRadioButtons[i]);
            }
            Controls.Add(colorGroup);
        }

        // Обработчик изменения CheckBox
        private void ModeCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            bool isRadioMode = modeCheckBox.Checked;
            colorGroup.Visible = isRadioMode;

            // Включаем/выключаем кнопки в зависимости от режима
            foreach (Button btn in colorButtons)
            {
                btn.Enabled = !isRadioMode;
            }

            // Включаем/выключаем RadioButton в зависимости от режима
            foreach (RadioButton rb in colorRadioButtons)
            {
                rb.Enabled = isRadioMode;
            }
        }

        // Обработчик клика по кнопке
        private void ColorButton_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            ApplyColor((AppColor)btn.Tag); // Используем сохраненное значение enum
        }

        // Обработчик выбора RadioButton
        private void ColorRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            if (rb.Checked)
            {
                ApplyColor((AppColor)rb.Tag); // Используем сохраненное значение enum
            }
        }

        // Метод изменения цвета фона с использованием enum
        private void ApplyColor(AppColor color)
        {
            switch (color)
            {
                case AppColor.Красный:
                    BackColor = Color.Red;
                    break;
                case AppColor.Зелёный:
                    BackColor = Color.Green;
                    break;
                case AppColor.Синий:
                    BackColor = Color.Blue;
                    break;
                case AppColor.Фиолетовый:
                    BackColor = Color.Purple;
                    break;
                case AppColor.Оранжевый:
                    BackColor = Color.Orange;
                    break;
                case AppColor.Белый:
                    BackColor = Color.White;
                    break;
                case AppColor.Стандартный:
                    BackColor = Color.Gray;
                    break;
            }
        }
    }
}