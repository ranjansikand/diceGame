# Dicetro

**Dicetro** is a prototype concept for a dice-based autobattler inspired by *Balatro* and *Super Auto Pets*.  
Players build a lineup of synergistic dice that roll automatically each round, chaining effects and scoring patterns to climb toward ever-higher score thresholds.

This project explores procedural item design, modular dice logic, and emergent combo systems — all framed in a compact, easy-to-parse linear layout.

---

## Overview

In **Dicetro**, each die represents a unit in your formation.  
Dice roll automatically in sequence, triggering passive and reactive effects based on their neighbors and the results of the roll.  
The goal is to build a synergistic lineup that generates massive scores through chaining multipliers, combos, and faction bonuses.

The core design pillars are:
- **Simplicity:** Easy to understand at a glance; depth through interaction, not complexity.
- **Expression:** Every die can create unique chain reactions based on lineup order.
- **Replayability:** Procedurally generated dice and effects allow endlessly variable runs.

---

## Core Gameplay Loop

1. **Shop Phase**
   - Purchase new dice from a rotating shop.
   - Combine or upgrade dice to enhance their effects.
   - Rearrange your lineup to optimize synergy.

2. **Battle Phase**
   - All dice roll simultaneously.
   - Abilities trigger left-to-right in the lineup.
   - Combos and multipliers are calculated based on results and positioning.
   - You earn points based on total combo score.

3. **Progression**
   - Meet or exceed the round’s score target to advance.
   - Face new modifiers, boss effects, and dice pool variations.

---

## Project Goals

This prototype was developed as a **design and systems exploration** rather than a full game release.  
Key areas of focus include:
- Modular dice architecture using scriptable objects or composable data.
- Procedural generation of dice traits and scoring effects.
- Balancing readable combat automation with deep combo potential.
- Designing for clarity in both visuals and system communication.

---

## Future Development Ideas

- Add more dice “factions” such as Machines, Cultists, or Spirits.  
- Introduce boss modifiers that alter how dice roll or score.  
- Implement persistent meta-progression (e.g., unlockable die sets or themes).  
- Add visual polish and sound feedback to emphasize scoring peaks.  

---

## Technologies

**Engine:** Unity (C#)  
**Focus Areas:** System design, procedural generation, and UI logic  
**Status:** Prototype / Concept phase  

---

## License

This project is released for portfolio and educational purposes.  
All rights reserved by the author.

---

## Author

**Ranjan Sikand**  
Game Designer & Developer  
[LinkedIn](https://www.linkedin.com/in/ranjan-sikand) | [GitHub](https://github.com/ranjansikand)
