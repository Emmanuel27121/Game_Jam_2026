# Unity Project README

## Overview

This repository contains the initial setup for a Unity project. At this stage, the project uses Unity’s default configuration with no custom assets and no changes to the initial project settings.

The purpose of this repository is to provide a shared starting point for all collaborators. Each contributor is expected to clone the repository locally and configure the project in Unity using the specified Unity version.

---

## Unity Version

**Required Unity Version:** `2022.3.62f3` (LTS)

All collaborators must use this exact version to avoid compatibility issues. It is strongly recommended to install it via **Unity Hub**.

---

## Getting Started (Step-by-Step)

This section walks through **every step** needed to get the project running locally. All commands are safe to copy‑paste.

---

### 1. Install Prerequisites

Make sure you have the following installed:

* **Git** → [https://git-scm.com/](https://git-scm.com/)
* **Unity Hub** → [https://unity.com/download](https://unity.com/download)
* **Unity Editor version 2022.3.62f3 (LTS)** (installed via Unity Hub)

You can confirm Git is installed by running the following in your terminal:

```bash
git --version
```

If a version number prints, Git is installed.

---

### 2. Choose a Folder for the Project

Navigate to a directory where you keep your projects. For example:

```bash
cd ~
cd Documents
mkdir UnityProjects
cd UnityProjects
```

> You can choose any location you like — just make sure you remember where it is.

---

### 3. Clone the Repository

Clone the repository into your current directory:

```bash
git clone https://github.com/d3n-ze1/game-jam-2025.git
```

This creates a new folder with the project name. Move into it:

```bash
cd game-jam-2025
```

Confirm you are inside a Git repository:

```bash
git status
```

You should see something like:

```
On branch main
nothing to commit, working tree clean
```
Check out the files inside the project:

```
ls
```
You should see  Assets, Packages, ProjectSettings, .gitignore
---

### 4. Open the Project in Unity Hub

1. Open **Unity Hub**
2. Go to **Projects** → **Open**
3. Select the cloned repository folder (the one you just `cd`’d into)

Unity Hub should detect the project automatically.

---

### 5. Verify the Unity Version

When opening the project, ensure Unity Hub uses:

```
Unity 2022.3.62f3
```

If Unity Hub prompts you to install the version, do so before opening.

Once opened, Unity will automatically generate local files (Library, Temp, etc.). This is expected.

---

### 6. Create the Development Branch (Once `dev` Exists)

Switch to the `dev` branch, using:

```bash
git fetch
git checkout dev
```

Confirm you are on the correct branch:

```bash
git branch
```

You should see:

```
* dev
  main
```

---

### 7. Create Your Own Feature / Task Branch
-- Ignore this section unti the game jam

Before doing any work, create a personal branch **from `dev`**:

```bash
git checkout -b feature/your-feature-name
```

Examples:

```bash
git checkout -b feature/player-movement
git checkout -b task/ui-layout
git checkout -b bugfix/camera-issue
```

Verify your branch:

```bash
git status
```

---

### 8. Working & Saving Changes

As you work in Unity:

* Unity automatically saves scene and asset changes
* New files will appear as untracked in Git

Check your changes:

```bash
git status
```

Stage your changes:

```bash
git add .
```

Commit with a clear message:

```bash
git commit -m "Add basic player movement"
```

---

### 9. Push Your Branch to the Remote Repository

The first time you push your branch:

```bash
git push -u origin feature/your-feature-name
```

After that, future pushes can use:

```bash
git push
```

---

### 10. Keeping Your Branch Up to Date

Before starting new work each day:

```bash
git checkout dev
git pull
```

Then update your feature branch:

```bash
git checkout feature/your-feature-name
git merge dev
```

Resolve any conflicts if prompted.

---

Once opened, Unity will generate any necessary local files automatically.

---

## Branching Strategy

* **`main`**

  * Stable branch
  * Contains production-ready or milestone-approved work

* **`dev`** 

  * Integration branch for ongoing development
  * Features should be merged here before reaching `main`

* **Feature / Task Branches**

  * Each collaborator should create their own branch for assigned tasks or features
  * Recommended naming convention:

    * `feature/<feature-name>`
    * `bugfix/<issue-name>`
    * `task/<short-description>`

> Do not commit directly to `main`.

---

## Git & Unity Notes

* Unity will generate local and machine-specific files on first open
* These files should **not** be committed unless explicitly required
* The `.gitignore` should already handle common Unity-generated files

If you add new packages, assets, or settings that affect the whole project, ensure they are committed properly.

---

## Collaboration Guidelines (Initial)

* Pull the latest changes before starting work
* Keep commits small and descriptive
* Test your changes locally before pushing
* Open a pull request when merging into `dev` or `main`

These guidelines may be expanded as the project grows.

---

## Current Project State

* No custom assets
* Default Unity project settings
* No external dependencies
* No scenes beyond Unity defaults

This README will evolve as the project structure and scope become clearer.

---

## Recommendations / Future Additions
TBD

---

## Questions or Issues

If you encounter setup issues or have questions, reach out to Ore or Dili (or google it, walahi).
