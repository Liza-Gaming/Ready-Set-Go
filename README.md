# היכון, הכן, צא! ⏰
**משחק התארגנות שלוקח אתכם מהיום יום אל חוויה - תכננו, אספו ונצחו 🎒**

מחפשים חוויה שמאחדת תשוקה למשחקים עם מטרה חשובה? הצטרפו להרפתקה שתשפר את כישורי ההתארגנות שלכם ותעניק לכם עצמאות אמיתית - ברוכים הבאים ל'היכון, הכן צא!'.

[שחקו במשחק](https://lizachep.itch.io/final-game-house), [טריילר](https://www.youtube.com/watch?v=IuT27F8H6o8&ab_channel=LizaChepurko)


![Screenshot 2024-12-15 212018](https://github.com/user-attachments/assets/ac7cac38-557c-46ac-bda6-3d7f59f225df)


## מהות המשחק
המשחק הוא חוויה תלת-ממדית המיועדת למבוגרים עם לקות שכלית בינונית עד גבולית וקשיים בארגון ותכנון יומי. 
השחקנים מתמודדים עם אתגרים של התארגנות על מנת להגיע לאירועים שונים, תוך שימוש ברמזים או רשימות. בכל חדר בדירה, הם צריכים לאסוף פריטים חיוניים כמו בגדים, אוכל ונעליים, תוך כדי פתרון משחקים קטנים ודילמות חווייתיות.
בסוף המשחק, זמן האתרגנות של השחקנים נשמר בענן ומוצג בלוח התוצאות כך שיתאפשר מעקב אחר הביצועים.
המטרה של המשחק היא לעזור לקהל היעד לאמץ כישורי התארגנות ובכך להגדיל את עצמאותם.

[formal elemnts](https://github.com/Liza-Gaming/Ready-Set-Go/blob/main/formal-elements.md)

[dramatic elements](https://github.com/Liza-Gaming/Ready-Set-Go/blob/main/dramatic-elements.md)
## פיצ'רים 🚀
- **חוויה תלת-ממדית מרתקת:** סביבה וירטואלית שמחקה את המציאות אותה שחקננים יכולים לחקור.
- **התאמת המשחק לרמת השחקן:** לא רק שהשחקן יכול לבחור את זמן ההתארגנות, אלא שאם הוא מתקשה במהלך משימה, המשימה תהיה קלה יותר (לדוגמא - הזמן יירד לאט יותר)
- **אתגרים יומיומיים:** איסוף פריטים חיוניים בכל חדר, כגון בגדים, אוכל ונעליים.
- **משחקים קטנים ודילמות:** פתרון בעיות ולקיחת החלטות לשיפור הקוגנטיביות.
- **מערכת דירוג:** קבלת משוב מיידי על ביצועים וכישורי התארגנות בסוף המשחק, מאפשר מעקב אחר הביצועים של השחקן.
- **רשימה מתעדכנת:** השחקן יכול לראות מה הוא השלים ומה נשאר לו.
- **מערכת רמזים.**
- **צלילים:** מספקים משוב.

## תרשים זרימה

![Screenshot 2024-11-27 113004](https://github.com/user-attachments/assets/b2121c8a-ffba-4e60-b5f2-7617a50a7d6d)

## מבנה בקבצים (מתעדכן)
```bash
Assets/
│
├── Scenes/
│   ├── Intro
│   ├── Sample Scene
│   ├── Stove
│   ├── Fridge
│   ├── Wardrobe
│   ├── Desk
│   ├── Towel
|   ├── OpenDoor
|   ├── Instractions
|   ├── ChooseTime
|   ├── GameOver
|   ├── Win
|   └── HistoryScene
|
├── Scripts/
│   │
│   ├── Intro Scene/
│   │   ├── ButtonScript.cs
│   │   └── IntroVideoPlayer.cs
│   │
│   ├── Kitchen Scene/
│   │   └── Stove/
│   │       └── StoveSliderBar.cs
│   │
│   ├── Wardrobe Scene/
│   │   ├── BasketBehavior.cs
│   │   ├── BasketMover.cs
│   │   ├── ClothingSpawner.cs
│   │   ├── Mover.cs
│   │   └── Prefabs/
│   │
│   ├── Instructions/
|   |   └── slideshow.cs
|   |   
|   ├── OpenDoorScene/
|   |    └── HoverDisplay.cs   
|   |
|   ├── ChooseTimeScene/
|   |    ├── TimeSettings.cs
|   |    └── TimeSelectionManager.cs
│   │
│   ├── Player/
│   │   ├── MoveLogic/
│   │   |   ├── ButtonHandler.cs
│   │   │   ├── CameraBob.cs
|   |   |   ├── KeyBoardController.cs
│   │   │   └── Movement.cs
│   │   ├── PlayerManager.cs
│   │   ├── UIManager.cs
│   │   ├── HoverMove.cs
│   │   └── MissionTrigger.cs
│   │
│   ├── RetryGame/
|   |   ├── CloudSave.cs
|   |   ├── ScoreboardController.cs
|   |   ├── NavigateToHistory.cs
|   |   ├── WinSceneController.cs
|   |   └── RetryGame.cs
|   | 
│   ├── Utils/
|   |   ├── AudioManager.cs
│   │   ├── DisplayImage.cs
│   │   ├── DoorInteraction.cs
│   │   ├── SceneController.cs
│   │   ├── SceneLoader.cs
│   │   ├── Selection.cs
│   │   ├── SelectItems.cs
│   │   ├── SliderController.cs
│   │   ├── SliderBar.cs
|   |   ├── SliderControllerDesk.cs
|   |   ├── SliderControllerPicture.cs
|   |   ├── TaskInstructions.cs
│   │   └── Timer.cs
│   │
└── └── UI/
```


# תודות

**קודים**

ברצוני להודות למגוון המשאבים הזמינים בפלטפורמות כמו YouTube וצ'אט GPT, שהיו לי לעזר רב לאורך תהליך הפיתוח. כל סקריפט שנעשה בו שימוש ונכתב על ידי יוצרים אחרים תועד כראוי בתיעוד הקוד. אני אסירת תודה על הידע הרב שזכיתי ללמוד במסע המיוחד הזה.

**נכסים**

[נכסי רהיטים](https://kenney.nl/assets/furniture-kit), [נכסי אוכל](https://kenney.nl/assets/food-kit), [בגדים](https://assetstore.unity.com/packages/3d/characters/humanoids/creative-characters-free-animated-low-poly-3d-models-304841), [נכסים נוספים](https://assetstore.unity.com/packages/3d/props/simple-free-beach-models-287370)

**טקסטורות**

[מטבח](https://assetstore.unity.com/packages/3d/props/furniture/kitchen-furniture-starterpack-209331), [חומרים](https://assetstore.unity.com/packages/3d/props/p3d-indoor-design-starter-kit-3d-models-furniture-264116)

**פני שטח**

[פני שטח](https://assetstore.unity.com/publishers/57553)

**ממשק**

[פונט פיקסלים](https://assetstore.unity.com/packages/2d/fonts/free-pixel-font-thaleah-140059), [כפתורים וסמלים](https://assetstore.unity.com/packages/2d/gui/icons/fun-hyper-casual-ui-pack-free-302632), כלי עיצוב -[Canva](https://www.canva.com/)

**סאונדים**

[סאונדים](https://assetstore.unity.com/packages/audio/sound-fx/free-casual-game-sfx-pack-54116)

**טריילר משחק**
[animaker](https://www.animaker.com/)

**תודות נוספות**

אני מודה למרצה אראל דוד סגל-הלוי על המידע שהועבר במסגרת קורס פיתוח משחקי מחשב באריאל ולמתרגל ויקטור קושניר שעזר לי לפתור תקלות במשחק.

## פיתוח

**פיתוח המשחק:** אליזבט צ'פורקו

**צוות ריפוי בעיסוק:**
עינב כהן, בנייה קליין ואוריה משולם



