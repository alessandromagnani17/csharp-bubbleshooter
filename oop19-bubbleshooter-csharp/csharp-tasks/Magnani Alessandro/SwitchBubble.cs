﻿using System;

namespace csharp_tasks.Magnani_Alessandro
{
    class SwitchBubble : AbstractBubble
    {
        /**
         * 
         * @param position The position in the game.
         * @param color    The {@link BubbleColor} of the bubble.
         */
        public SwitchBubble(Point position, BubbleColor color) : base(BubbleType.SWITCH_BUBBLE, position, color) 
        {
        }

        /**
         * It has no component because it's useful only as {@link SwitchBubble} and it
         * has no functions in the game.
         */
        protected void SetComponents() 
        {
        }
    }
}
