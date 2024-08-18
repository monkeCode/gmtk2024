﻿using DefaultNamespace;
using UnityEngine;

namespace Events
{
    public class TaxEvasionEvent : EventBase
    {
        protected override int BaseEventDurationInSeconds => 60;
        protected override string Headline => "TAX EVASION";
        protected override string Description => "People began to avoid paying taxes. Lets inspect suspicious houses manually";
        protected override Sprite Image => null; //TODO: добавить пикчу

        public override void StartEvent(int eventDurationInSeconds)
        {
            base.StartEvent(eventDurationInSeconds);
            Flags.TaxEvasionEventFlag = true;
        }

        protected override void EndEvent()
        {
            base.EndEvent();
            Flags.TaxEvasionEventFlag = false; // На выходе из ивента не появляются кружочки у домов под ивентом. Мб через юнити ивенты подписываться и показывать потом
        }
    }
}