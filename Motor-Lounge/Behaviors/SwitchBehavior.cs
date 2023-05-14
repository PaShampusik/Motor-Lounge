using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Motor_Lounge.Behaviors
{
    public class SwitchBehavior : Behavior<Switch>
    {
        public static readonly BindableProperty CommandProperty =
            BindableProperty.Create(nameof(Command), typeof(ICommand), typeof(SwitchBehavior));

        public ICommand Command
        {
            get => (ICommand)GetValue(CommandProperty);
            set => SetValue(CommandProperty, value);
        }

        protected override void OnAttachedTo(Switch switchControl)
        {
            base.OnAttachedTo(switchControl);
            switchControl.Toggled += OnSwitchToggled;
        }

        protected override void OnDetachingFrom(Switch switchControl)
        {
            base.OnDetachingFrom(switchControl);
            switchControl.Toggled -= OnSwitchToggled;
        }

        private void OnSwitchToggled(object sender, ToggledEventArgs e)
        {
            if (Command != null && Command.CanExecute(e.Value))
            {
                Command.Execute(e.Value);
            }
        }
    }
}
