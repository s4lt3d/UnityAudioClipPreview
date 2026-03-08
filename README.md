# Unity Audio Clip Preview

> An editor tool that adds audio preview controls directly to AudioClip inspectors in Unity.

---

## Overview

This is a simple but powerful editor extension that lets you preview audio clips directly from the Inspector without leaving your workflow.

---

## Installation

1. Place `AudioClipPreviewDrawer` script in `Assets/Editor/` or any `Editor` folder
2. Restart or reload scripts in Unity
3. Select any AudioClip asset to see the preview controls

---

## Features

- **Inspector Preview** — Play audio directly from AudioClip inspector
- **Playback Controls** — Play, pause, and seek controls
- **Fast Workflow** — No need to attach clips to GameObjects for preview
- **Non-Intrusive** — Works alongside standard AudioClip inspector

---

## Compatibility

- **Tested:** Unity 6.0+
- **Earlier Versions:** May work with Unity 2020 LTS and later

---

## Screenshot

<img width="518" alt="Audio Clip Preview in Inspector" src="https://github.com/user-attachments/assets/771462d5-02d4-45d4-bb14-2b4f4bc9c563" />

---

## How It Works

The script uses a `PropertyDrawer` to extend the default AudioClip inspector, adding playback controls without modifying your assets.

---

## Getting Started

### Installation

1. **Create Editor Folder**
   ```
   Assets/Editor/
   ```

2. **Place Script**
   - Copy `AudioClipPreviewDrawer.cs` to `Assets/Editor/`
   - Any subfolder of `Assets/Editor/` works

3. **Restart Unity**
   - Unity recompiles scripts
   - Click any AudioClip to see preview controls

### Quick Test

1. Select any `.mp3` or `.wav` file in project
2. Look in Inspector
3. New preview controls appear below default AudioClip info
4. Click Play to hear audio

---

## Usage

### Preview Controls

When you select an AudioClip:

- **Play Button** — Start playback
- **Pause Button** — Pause audio
- **Stop Button** — Stop and reset to start
- **Time Slider** — Scrub through audio
- **Time Display** — Current time / Total duration
- **Volume Slider** — Adjust preview volume

### Keyboard Shortcuts

While focused on preview:

- **Spacebar** — Play/Pause
- **Left Arrow** — Jump back 0.5s
- **Right Arrow** — Jump forward 0.5s
- **Home** — Jump to start
- **End** — Jump to end

### Multiple Clips

- Select different AudioClips to preview each
- Controls update automatically
- Stops playback when deselecting clip

---

## Features in Detail

### Inspector Integration

- **Non-intrusive** — Doesn't modify inspector layout
- **Always visible** — Shows above standard clip info
- **Clean UI** — Minimal design
- **Touch-friendly** — Large buttons for mobile

### Audio Playback

- **Accurate playback** — Uses Unity's audio engine
- **Volume control** — Preview at any volume
- **Seek precision** — Accurate time scrubbing
- **Real-time feedback** — Instant response

### Workflow Enhancement

- **No context switching** — Preview without leaving Inspector
- **Time saving** — Faster than creating test GameObjects
- **Testing clips** — Quickly verify audio content
- **Asset checking** — Confirm clips before using

---

## Customization

### Change Button Layout

Edit the `OnGUI` method:
```csharp
// Customize button sizes, spacing, colors
GUI.backgroundColor = Color.green;
if (GUILayout.Button("Custom Label")) {
    // Custom behavior
}
```

### Add Playback Indicators

Show playback status:
```csharp
if (EditorApplication.isPlaying) {
    EditorGUILayout.LabelField("Status: Playing");
}
```

### Loop Playback

Add loop option:
```csharp
loopPreview = EditorGUILayout.Toggle("Loop", loopPreview);
if (loopPreview) {
    // Restart at end
}
```

---

## Limitations

### Known Issues

- **No pitch control** — Can't adjust preview pitch
- **Single playback** — Only one clip at a time
- **No 3D audio** — Stereo/mono only
- **Inspector only** — Can't preview in scene view

### Workarounds

- Use **Scene Audiosource** for complex testing
- Create **Test GameObjects** for spatial audio
- Use **External players** for advanced features
- Check **Import settings** for audio properties

---

## Troubleshooting

### Preview Doesn't Appear

- Script in `Assets/Editor/` folder?
- Syntax errors in console?
- AudioClip selected?
- Restart Unity if needed

### No Sound

- Check system volume
- Verify audio output
- Ensure clip has audio data
- Check preview volume slider

### Buttons Not Responding

- Check if clip is valid
- Ensure Editor script is loaded
- Try selecting different clip
- Look for console errors

---

## Performance

### Impact

- **Minimal overhead** — Lightweight PropertyDrawer
- **No background processing** — Only active when viewing clip
- **Instant startup** — No async operations
- **Memory efficient** — Small memory footprint

### Optimization

- Playback uses Unity audio engine
- No duplicate audio loading
- Efficient UI rendering
- Stops on deselect

---

## Advanced Usage

### Batch Preview

1. Select folder of AudioClips
2. Multi-select clips in inspector
3. Use dropdown to switch between selected clips
4. Preview each in sequence

### Integration with Workflow

- Preview during sound design
- Check before assigning to GameObjects
- Verify clip durations
- Test audio quality before build
- Confirm mono vs stereo

### Custom Metadata Display

Show clip information:
```csharp
// Display in preview
EditorGUILayout.LabelField($"Channels: {clip.channels}");
EditorGUILayout.LabelField($"Sample Rate: {clip.frequency}Hz");
EditorGUILayout.LabelField($"Length: {clip.length:F2}s");
```

---

## Best Practices

### Audio Workflow

- Batch preview audio before importing
- Check import settings impact on quality
- Verify naming conventions during preview
- Organize clips by category while reviewing

### Productivity

- Use as quick reference tool
- Don't rely entirely on preview quality (may differ in-game)
- Test final audio in actual scenes
- Use alongside dedicated audio editors

---

## Future Enhancements

- Waveform visualization
- Pitch adjustment
- Playback speed control
- Multi-clip preview
- Spectrum analyzer
- Recording capability

---

## Technical Details

- **Type:** PropertyDrawer
- **Target:** AudioClip assets
- **Location:** Assets/Editor/
- **Dependencies:** None (built-in APIs)
- **Compatibility:** Unity 2020.3+

---

## License

Copyright © Walter Gordy


