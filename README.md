# CSCI5619-FinalProject
**Due: Thursday, December 16, 4:00pm CDT**

## Submission Information

Names: Christian Halvorson, Michael Boschwitz, Kerri Newcomer

UMN Emails: Halvo482, bosch137, newco098

Third Party Assets: Asset Forge Deluxe `ADD LINK HERE`, Various 3D Assets: KenneyNL `ADD LINK HERE`, Portals based off Brackeys video (https://www.youtube.com/watch?v=cuQao3hEKfs), Stencil buffer based on Ronja's tutorial (https://www.ronja-tutorials.com/post/022-stencil-buffers/)

## Design Implementation

- Demo
    - We decided to make a demo that shows off a range of "impossibleness."
    - The three floors increase in how much they overlap.
- Floor one
    - Simple overlapping rooms.
    - This floor should be undetectable unless the user is really looking.
- Floor two
    - This floor uses a circular system of rooms and hallways to reorient and reposition the user.
    - While a keen user might notice the overlap, we found that it is much more difficult to detect than we thought.
- Floor three
    - The rooms in this floor overlap on themselves in a way that should be obvious to the user.
    - We found that the overlap was not jarring and did not take away from the experience.

## Technical Implementation

- VR portals
    - Extended Brackeys' portals to work on android VR.
    - These ended up being too slow on mobile VR for our purposes.
- Stencil buffer
    - Shader system that only renders the room the user is in.
    - The adjacent rooms are rendered through stencil masks in the doorways.
    - Stencil layer is changed when user enters a new room.
- Elevator Reset
    - The user can walk around the floor and then enter the elevator to travel to the next floor.
    - Elevator closes, loads the next scene, and then opens to the next floor.
    - This "resets" the space to be used for another design.