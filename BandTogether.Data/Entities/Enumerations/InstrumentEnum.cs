using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BandTogether.Data.Entities
{
    public enum Instrument 
    { 
        Piccolo = 1,
        Flute, 
        Oboe,
        [Display(Name = "English Horn")]
        EnglishHorn, 
        Bassoon,
        [Display(Name = "Eb Clarinet")]
        EbClarinet,
        Clarinet,
        [Display(Name = "Bass Clarinet")]
        BassClarinet,
        [Display(Name = "Soprano Saxophone")]
        SopranoSaxophone,
        [Display(Name = "Alto Saxophone")]
        AltoSaxophone,
        [Display(Name = "Tenor Saxophone")]
        TenorSaxophone,
        [Display(Name = "Bari Saxophone")]
        BariSaxophone, 
        Horn,
        Mellophone,
        Trumpet, 
        Trombone, 
        Euphonium, 
        Baritone, 
        Tuba,
        [Display(Name = "Snare Drum")]
        SnareDrum, 
        Bells, 
        Xylophone, 
        Vibraphone, 
        Marimba, 
        Timpani,
        [Display(Name = "Tenor Drum")]
        TenorDrums,
        [Display(Name = "Bass Drum")]
        BassDrum, 
        Cymbals, 
        Guitar,
        [Display(Name = "Electric Bass")]
        ElectricBass,
        [Display(Name = "String Bass")]
        StringBass, 
        DrumSet, 
        Piano 
    }
}
