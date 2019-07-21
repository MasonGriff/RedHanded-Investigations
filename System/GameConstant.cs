using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameConstant{

    public bool GameConstantSet; //sets to "on" once game.current has been set.

    public int FingerprintSlotToUpdateNext; //Determines which of the 3 slots will be overwritten next time you take fingerprints
    /*  ==== Characters Fingerprints ====
     * 0: <empty>
     * 1: Mike Griffin [guy in purple]
     * 2: John Riley [guy in green]
     * 3: Mack Charles [guy in blue]
     * 4: Mary Charles [woman in red]
     * 5: Kasie Babiuch [woman in pink]
    */
    public int FingerprintSlot1; //Determines which character from the list above is being depicted in the slot. Same for Slot 2 and 3 below
    public int FingerprintSlot2;
    public int FingerprintSlot3;

    public int SufficientEvidence; //Checks if player gathered enough evidence for proving guilt of actul culprit
    //=== Sufficient Evidence Bools ===
    public bool SufEviWeaponPrints;
    public bool SufEviWifeLiedAlibi;
    public bool SufEviWifeLiedWeapon;
    public bool SufEviWifeLiedMoney;
    public bool SufEviFoundInsurance;
    public bool SufEviInsurancePrints;
    public bool SufEviBlame1;
    public bool SufEviBlame3;
    public bool SufEviBlame5;
    //Sufficient Evidence Total = 9
    public int LoadingOpening;

    //=== Between Scenes ===
    public int CurrentInterrogate; //set to Person's number (numbers are the names above). 0 means you aren't in interrogation room.
    public bool FoundWeapon;
    public bool SearchedWallet;
    public int PeopleTalkedTo;
    public bool InitialInspectBody;
    public bool ExaminedBody;
    public bool CheckedTrash;

    //=== Interrogate Mentioned ===
    public bool AccountantMentionedMoney;
    public bool WifeMentionedMoney;
    public int  ImportantMentionedMoney;
    public bool BrotherIsDead;
    public bool BrotherSeesWeapon;
    public bool BrothersAlibi;
    public bool WifesFirstAlibi;
    public bool WifesSecondAlibi;
    public bool TrashCanMentioned;

    //=== Important Fingerprint Matched ===
    public bool WeaponPrintsMatched;

    public bool Person1TalktedTo;
    public bool Person2TalktedTo;
    public bool Person3TalktedTo;
    public bool Person4TalktedTo;
    public bool Person5TalktedTo;

    public bool GameplayPaused;

    public string RoomLastVisited;

    public bool theEnd;

    public GameConstant()
    {
        //sets everything for when new game is started
        this.FingerprintSlotToUpdateNext = 1;
        this.FingerprintSlot1 = 0;
        this.FingerprintSlot2 = 0;
        this.FingerprintSlot3 = 0;
        SufficientEvidence = 0;

        FoundWeapon = false;
        SearchedWallet = false;
        PeopleTalkedTo = 0;
        ExaminedBody = false;

        Person1TalktedTo = false;
        Person2TalktedTo = false;
        Person3TalktedTo = false;
        Person4TalktedTo = false;
        Person5TalktedTo = false;

        AccountantMentionedMoney = false;
        WifeMentionedMoney = false;
        ImportantMentionedMoney = 0;
        BrotherIsDead = false;
        BrotherSeesWeapon = false;
        BrothersAlibi = false;
        WeaponPrintsMatched = false;
        WifesFirstAlibi = false;
        WifesSecondAlibi = false;
        InitialInspectBody = false;
        TrashCanMentioned = false;
        CheckedTrash = false;

        CurrentInterrogate = 0;
        GameplayPaused = false;

        RoomLastVisited = "";


        SufEviBlame1 = false;
        SufEviBlame3 = false;
        SufEviBlame5 = false;
        SufEviFoundInsurance = false;
        SufEviInsurancePrints = false;
        SufEviWeaponPrints = false;
        SufEviWifeLiedAlibi = false;
        SufEviWifeLiedWeapon = false;
        SufEviWifeLiedMoney = false;

        theEnd = false;

        LoadingOpening = 0;
    }
}
