# DW-BuildingBlocks ReadMe

<img width="524" height="376" alt="image" src="https://github.com/user-attachments/assets/c8591879-8b99-4347-8fae-9760bf6f62c7" />

This is a visual scripting package I designed for my own usage, maybe I'll public it in the future once it is fully completed.

**DW-BuildingBlocks** is a modular visual scripting framework for Unity that allows developers to build gameplay logic using reusable, customizable action components—without writing complex code.

It provides a simple, extendable system where behaviors are constructed from small, focused "blocks" that can be executed sequentially.

### Update

!! DOTween Support package is now released.

https://github.com/DirtyLeon/DW-BuildingBlocks-addon-DOTween

---

## 1. Overview

DW-BuildingBlocks is built around two core concepts:

- **GameActions** – a Unity component that manages and executes logic  
- **ActionBlocks** – modular action units that perform specific tasks

Instead of writing custom scripts for every interaction, you can assemble functionality by stacking ActionBlocks inside a GameActions component and executing them in order.

---

## 2. Installation

Install the package directly through Unity Package Manager using the Git URL:

1. Open **Window → Package Manager**
2. Click **+ → Add package from git URL**
3. Enter: `https://github.com/DirtyLeon/DW-BuildingBlocks.git`
4. Click **Add**

---

## 3. How It Works

### GameActions Component

The **GameActions** component is the main controller.  
You attach it to any GameObject and use it to manage a list of ActionBlocks.

### ActionBlocks

ActionBlocks are individual units of behavior.  
Each block is a class derived from the base `ActionBlock` class.

---

## 4. Basic Usage

### Step-by-Step Workflow

1. Add the **GameActions** component to any GameObject.
2. In the Inspector, press the **“+”** button to add ActionBlocks to the list.
3. Configure each ActionBlock as needed.
4. Choose how to execute the list:
   - Automatically on **Start**
   - Automatically on **OnEnable**
   - Or manually via script:

```csharp
GetComponent<GameActions>().ExecuteList();
```

### Execution Flow

When executed, GameActions will:

1. Iterate through the list of ActionBlocks  
2. Run each block’s logic one by one in order  
3. Complete the sequence automatically  

This allows complex behavior to be built simply by combining small reusable pieces.

---

## 5. Requirements

- **Unity 2021.3 or higher** (recommended)
