using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BandTogether.Data.Entities.Enumerations
{
    public enum TheoryTopic
    {
        Rhythm = 1,
        Meter,
        Transposition,
        [Display(Name = "Note Recognition")]
        NoteRecognition,
        Triads,
        [Display(Name = "Seventh Chords")]
        SeventhChords,
        Scales,
        [Display(Name = "Rhythmic Dictation")]
        RhythmicDictation,
        [Display(Name = "Melodic Dictation")]
        MelodicDictation,
        [Display(Name = "Harmonic Dictation")]
        HarmonicDictation,
        [Display(Name = "Key Signatures")]
        KeySignatures,
        [Display(Name = "Roman Numeral Analysis")]
        RomanNumeralAnalysis,
        [Display(Name = "Sight Singing")]
        SightSinging,
        [Display(Name = "Musical Vocabulary")]
        MusicalVocabulary,
        Form,
        Intervals,
        [Display(Name = "Set Theory")]
        SetTheory,
        Cadences,
        Notation,
        Other
    }
}
