using System.Linq;
using UnityEngine.UIElements;

namespace Kogane.Internal
{
    internal static class ToolbarCreator
    {
        public static VisualElement Create()
        {
            var toolbar = new VisualElement
            {
                style =
                {
                    flexDirection = FlexDirection.RowReverse,
                    top           = 20,
                    right         = 1,
                },
                pickingMode = PickingMode.Ignore,
            };

            var setting = ConsoleWindowFilterToolbarSetting.instance;
            var list    = setting.List;

            if ( list is not { Length: > 0 } ) return toolbar;

            foreach ( var data in list.Where( x => x.IsValid ).Reverse() )
            {
                toolbar.Add( CreateButton( data.ButtonText, data.FilteringText ) );
            }

            toolbar.Add( CreateButton( "x", "" ) );

            return toolbar;
        }

        private static Button CreateButton
        (
            string buttonText,
            string filteringText
        )
        {
            return new( () => ConsoleWindowInternal.SetFilter( filteringText ) )
            {
                text = buttonText,
                style =
                {
                    marginLeft  = 0,
                    marginRight = 0,
                }
            };
        }
    }
}