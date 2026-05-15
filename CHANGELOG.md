# Changelog

All notable changes to **Hymnia** will be documented in this file.

> Hymnia is a fork of the original [SDAHymns](https://github.com/ThorSPB/SDAHymns) project, rebranded and extended for the Romanian Seventh Day Adventist Church community.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/), and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

---

## [1.0.2-beta] - 2026-05-15

### 🔄 Rebranding: SDAHymns → Hymnia

This release marks the official rebranding of the project from **SDAHymns** to **Hymnia**. The application is now distributed under the new name with updated namespaces, solution structure, and project references.

### Added
- **New Branding Icon** – Updated application icon with high-resolution assets for better visibility on Windows taskbar and start menu.
- **Settings Service** – Persistent user settings with profile-aware save/load, database migration support, and graceful fallback defaults.
- **Profile Editor** – Full UI for creating, editing, and deleting display profiles (fonts, colors, backgrounds, effects) with live preview.
- **Database Migration Support** – Automatic schema migration on startup; zero downtime upgrades between versions.
- **Cross-Platform Display Management** – Unified display service abstraction supporting Windows and Android targets.

### Changed
- **Project renamed** from `SDAHymns` → `Hymnia` across all namespaces, solution files, and project references.
- **Solution file** updated to `Hymnia.sln`; all `.csproj` references updated accordingly.
- **README** overhauled to reflect new branding, feature completeness, and roadmap status.
- **Build scripts** (Makefile, CI workflows) aligned with new Hymnia namespace and project paths.

### Fixed
- Resolved `Microsoft.Extensions` transitive dependency version conflicts by pinning to `10.0.5`.
- Fixed constructor mismatches in ViewModels introduced during the renaming refactor.
- Corrected Android project references after directory restructuring.

### Internal / Developer
- Removed deprecated service interface (`ILegacyHymnService`) and associated legacy configuration files.
- Improved `Directory.Build.props` with company, product, and copyright metadata.

---

## [1.0.1-beta] - 2026-05-15

### Added
- **Compact Remote Control Widget** (Spec 019) – Floating always-on-top widget for live worship operators, with numpad input, category selector, quick-slots, live slide counter, and black-screen toggle. Fully synced with main window and hotkeys.
- **Auto-Update UI in Remote Widget** – Velopack update notifications now surface in both the main window and the Remote Widget, ensuring operators never miss an update regardless of active mode.
- Localized all update-related strings in English and Romanian.

### Fixed
- GitHub Actions updated to Node.js 24-compatible action versions.
- Release workflow: safely handle multiline commit messages when generating release notes.
- macOS release: merge Velopack release indices manually to avoid `vpk` conflict errors.
- Fixed upload of `releases.json` assets for all platforms in CI.

---

## [1.0.0-beta] - 2026-05-14

### Added
- **Audio Playback & Recording System** (Spec 011) – NAudio-based piano recording player with sync, recorder mode, countdown timer, and audio device selection.
- **Audio Library Management** (Spec 014) – Download piano recordings from GitHub Releases or a local Pi server, verify checksums, migrate library between folders, and manage storage.
- **Display Profiles System** (Spec 007) – 6 preset display profiles plus a full profile editor (fonts, colors, background images, text effects). Profiles are persisted per-user.
- **Keyboard Shortcuts System** – Full hotkey support with an F1 overlay help panel and customizable bindings for all core operations.
- **Enhanced Control Window** – Search bar, browse mode, recent hymns list, and favorites system for rapid hymn access during live services.
- **Auto-Update System** – Seamless Velopack-based auto-update via GitHub Releases. Delta updates minimize download size. Supports Windows, macOS (ARM64), and Linux.
- **Smart Projection Layouts** – Context-aware layout switching: Inline Layout for numbered verses, Above/Left Layout for the Chorus (Refren), with smart label extraction and adaptive scaling.
- **Dual-Window System** – Operator control window + full-screen projection window optimized for congregations and OBS/streaming.
- **Preview Window** – Split-panel showing current hymn (large number + title) alongside dimmed next-hymn lyrics for seamless live navigation.
- **Multi-Category Hymnbook** – 1,254 hymns across 5 categories: Imnuri Creștine, Companions, Exploratori, Licurici, Tineret, and Diverse.
- **Offline-First Architecture** – Fully functional without internet; all hymn data stored in local SQLite database.
- **Windows Installer** – Self-contained, Velopack-packaged installer for Windows 10/11.

### Tech Stack
- C# / .NET 10 LTS
- Avalonia UI 11.x (cross-platform XAML)
- SQLite + Entity Framework Core 10.x
- NAudio 2.x for audio playback
- Velopack for auto-updates and installer packaging

---

## [Pre-Release / Legacy] — SDAHymns

Prior to the Hymnia rebranding, this project was developed under the name **SDAHymns** (also known internally as **SabbathDesk** during an intermediate development phase). The core hymn database, XML import pipeline, and initial display architecture originated in that era.

Key legacy milestones:
- Initial SQLite hymn database (1,254 hymns, 4,629 verses) from legacy XML sources.
- PowerPoint verse extraction for legacy content migration.
- Basic dual-window display prototype.
- Original SDA-themed icon and branding assets.

---

*For the full commit history, see the [git log](https://github.com/HopeAgent007/Hymnia/commits/main).*
