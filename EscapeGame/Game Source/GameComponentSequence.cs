using EscapeGame.Enums;
using EscapeGame.Models.GameComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EscapeGame.Models;
using System.Text.RegularExpressions;
using System.Windows.Shapes;

namespace EscapeGame.GameSource
{
    public class GameComponentSequence
    {
        #region Variables

        private int _currentIndex = -1;
        private readonly List<GameComponent> _sequenceDefinition = new List<GameComponent> {
            //new StoryMessage(RoomID.Story, Character.Robs, CharacterAction.Talking,
            //    new string[] {"Hallo und herzlich willkommen zu Escape la familia.",
            //    "Mein Name ist Robs und ich werde Sie durch den groben Spielablauf führen."}),
            new OpenRiddle(RoomID.Kitchen),
            new StoryMessage(RoomID.Story, Character.Robs, CharacterAction.Talking, new string[]{ "Eine Backzeit von (0) Minuten? ", "Pah..." }),
                //new string[]{ "Eine Backzeit von (0) Minuten? ",
                //       "Das wär ja noch schöner, wenn wir das hier 1:1 abbilden würden.",
                //        "Ich bin hier immernoch der Spielmaster! Das virtuelle Backen dauert...",
                //        "...fünf Sekunden! Habe ich soeben spontan entschlossen." }),
            new OpenRiddle(RoomID.Kitchen, ObjectID.Oven, ActionID.Bake)
        };

        #endregion

        #region Main

        public GameComponent GetNextComponent(string[] messageVariables)
        {
            GameComponent next = _sequenceDefinition[++_currentIndex];
            if (messageVariables?.Length > 0 && next.GetType() == typeof(StoryMessage))
            {
                StoryMessage storyMessage = (StoryMessage)next;
                storyMessage.Message = FillVariableMessage(storyMessage.Message, messageVariables);
            }
            return next;
        }

        private string[] FillVariableMessage(string[] message, string[] variables)
        {
            int variableCounter = 0;
            for (int i = 0; i < message.Length; i++)
            {
                variableCounter = FillVariableSentence(message, i, variables, variableCounter);
            }
            return message;
        }

        private int FillVariableSentence(string[] message, int sentenceIndex, string[] variables, int variableIndex)
        {
            while(message.GetValue(sentenceIndex).ToString().Contains("(0)"))
            {
                if (variableIndex >= variables.Length) return variableIndex; //fallback for OutOfBounds
                message.SetValue(Regex.Replace(message.GetValue(sentenceIndex).ToString(), "(0)", variables[variableIndex]), sentenceIndex);
                variableIndex++;
            }
            return variableIndex;
        }

        #endregion

    }
}
