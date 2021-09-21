using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RelativeController : MonoBehaviour
{
    private string defaultName = "Relatiive";
    public ImageController startRelative;

    private ImageController _currentRelative;

    #region define relative names

    private Dictionary<int, Dictionary<int, string>> affinityMaleNames = new Dictionary<int, Dictionary<int, string>>()
    {
        [-4] = new Dictionary<int, string>
        {
            [6] = "Ururgroßneffe", [8] = "Ururgroßneffe 2. Grades", [8] = "Ururgroßneffe 3. Grades"
        },
        [-3] = new Dictionary<int, string>
            {[5] = "Urgroßneffe", [7] = "Urgroßneffe 2. Grades", [9] = "Urgroßneffe 3. Grades"},
        [-2] = new Dictionary<int, string>
            {[2] = "Schwiegerenkel", [4] = "Großneffe", [6] = "Großneffe 2. Grades", [8] = "Großneffe 3. Grades"},
        [-1] = new Dictionary<int, string>
        {
            [1] = "Schwiegersohn", [3] = "Neffe", [5] = "Neffe 2. Grades", [7] = "Neffe 3. Grades",
            [9] = "Neffe 4. Grades"
        },
        [0] = new Dictionary<int, string>
            {[0] = "Ehemann", [2] = "Schwager"},
        [1] = new Dictionary<int, string>
            {[1] = "Schwiegervater", [3] = "Onkel", [5] = "Onkel 2. Grades", [7] = "Onkel 3. Grades"},
        [2] = new Dictionary<int, string>
            {[2] = "Schwiegergroßvater", [4] = "Großonkel", [6] = "Großonkel 2. Grades", [8] = "Großonkel 3. Grades"},
        [3] = new Dictionary<int, string>
            {[5] = "Urgroßonkel", [7] = "Urgroßonkel 2. Grades", [9] = "Urgroßonkel 3. Grades"},
        [4] = new Dictionary<int, string>
            {[6] = "Ururgroßonkel", [8] = "Ururgroßonkel 2. Grades"},
    };

    private Dictionary<int, Dictionary<int, string>> affinityFemaleNames =
        new Dictionary<int, Dictionary<int, string>>()
        {
            [-4] = new Dictionary<int, string>
            {
                [6] = "Ururgroßnichte", [8] = "Ururgroßnichte 2. Grades",
                [8] = "Ururgroßnichte 3. Grades"
            },

            [-3] = new Dictionary<int, string>
                {[5] = "Urgroßnichte", [7] = "Urgroßnichte 2. Grades", [9] = "Urgroßnichte 3. Grades"},

            [-2] = new Dictionary<int, string>
            {
                [2] = "Schwiegerenkelin", [4] = "Großnichte", [6] = "Großnichte 2. Grades", [8] = "Großnichte 3. Grades"
            },

            [-1] = new Dictionary<int, string>
            {
                [1] = "Schwiegertochter", [3] = "Nichte", [5] = "Nichte 2. Grades", [7] = "Nichte 3. Grades",
                [9] = "Nichte 4. Grades"
            },

            [0] = new Dictionary<int, string>
                {[0] = "Ehefrau", [2] = "Schwägerin"},

            [1] = new Dictionary<int, string>
                {[1] = "Schwiegermutter", [3] = "Tante", [5] = "Tante 2. Grades", [7] = "Tante 3. Grades"},

            [2] = new Dictionary<int, string>
            {
                [2] = "Schwiegergroßmutter", [4] = "Großtante", [6] = "Großtante 2. Grades", [8] = "Großtante 3. Grades"
            },

            [3] = new Dictionary<int, string>
                {[5] = "Urgroßtante", [7] = "Urgroßtante 2. Grades", [9] = "Urgroßtante 3. Grades"},

            [4] = new Dictionary<int, string>
                {[6] = "Ururgroßtante", [8] = "Ururgroßtante 2. Grades"}
        };

    private Dictionary<int, Dictionary<int, string>> maleNames = new Dictionary<int, Dictionary<int, string>>()
    {
        [-4] = new Dictionary<int, string>
        {
            [4] = "Ururenkel", [6] = "Ururgroßneffe", [8] = "Ururgroßneffe 2. Grades", [8] = "Ururgroßneffe 3. Grades"
        },
        [-3] = new Dictionary<int, string>
            {[3] = "Urenkel", [5] = "Urgroßneffe", [7] = "Urgroßneffe 2. Grades", [9] = "Urgroßneffe 3. Grades"},
        [-2] = new Dictionary<int, string>
            {[2] = "Enkel", [4] = "Großneffe", [6] = "Großneffe 2. Grades", [8] = "Großneffe 3. Grades"},
        [-1] = new Dictionary<int, string>
            {[1] = "Sohn", [3] = "Neffe", [5] = "Neffe 2. Grades", [7] = "Neffe 3. Grades", [9] = "Neffe 4. Grades"},
        [0] = new Dictionary<int, string>
            {[0] = "Ich", [2] = "Bruder", [4] = "Cousin", [6] = "Cousin 2. Grades", [8] = "Cousin 3. Grades"},
        [1] = new Dictionary<int, string>
            {[1] = "Vater", [3] = "Onkel", [5] = "Onkel 2. Grades", [7] = "Onkel 3. Grades"},
        [2] = new Dictionary<int, string>
            {[2] = "Großvater", [4] = "Großonkel", [6] = "Großonkel 2. Grades", [8] = "Großonkel 3. Grades"},
        [3] = new Dictionary<int, string>
            {[3] = "Urgroßvater", [5] = "Urgroßonkel", [7] = "Urgroßonkel 2. Grades", [9] = "Urgroßonkel 3. Grades"},
        [4] = new Dictionary<int, string>
            {[4] = "Ururgroßvater", [6] = "Ururgroßonkel", [8] = "Ururgroßonkel 2. Grades"},
    };

    private Dictionary<int, Dictionary<int, string>> femaleNames = new Dictionary<int, Dictionary<int, string>>()
    {
        [-4] = new Dictionary<int, string>
        {
            [4] = "Ururenkelin", [6] = "Ururgroßnichte", [8] = "Ururgroßnichte 2. Grades",
            [8] = "Ururgroßnichte 3. Grades"
        },

        [-3] = new Dictionary<int, string>
            {[3] = "Urenkelin", [5] = "Urgroßnichte", [7] = "Urgroßnichte 2. Grades", [9] = "Urgroßnichte 3. Grades"},

        [-2] = new Dictionary<int, string>
            {[2] = "Enkelin", [4] = "Großnichte", [6] = "Großnichte 2. Grades", [8] = "Großnichte 3. Grades"},

        [-1] = new Dictionary<int, string>
        {
            [1] = "Tochter", [3] = "Nichte", [5] = "Nichte 2. Grades", [7] = "Nichte 3. Grades",
            [9] = "Nichte 4. Grades"
        },

        [0] = new Dictionary<int, string>
            {[0] = "Ich", [2] = "Schwester", [4] = "Cousine", [6] = "Cousine 2. Grades", [8] = "Cousine 3. Grades"},

        [1] = new Dictionary<int, string>
            {[1] = "Mutter", [3] = "Tante", [5] = "Tante 2. Grades", [7] = "Tante 3. Grades"},

        [2] = new Dictionary<int, string>
            {[2] = "Großmutter", [4] = "Großtante", [6] = "Großtante 2. Grades", [8] = "Großtante 3. Grades"},

        [3] = new Dictionary<int, string>
            {[3] = "Urgroßmutter", [5] = "Urgroßtante", [7] = "Urgroßtante 2. Grades", [9] = "Urgroßtante 3. Grades"},

        [4] = new Dictionary<int, string>
            {[4] = "Ururgroßmutter", [6] = "Ururgroßtante", [8] = "Ururgroßtante 2. Grades"}
    };

    #endregion


    // Start is called before the first frame update

    void Start()
    {
        OnRelativeTapped(startRelative);
    }

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Ended)
            {
                HandleTap(touch.position);
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            HandleTap(Input.mousePosition);
        }
    }

    private void HandleTap(Vector2 position)
    {
        Ray ray = Camera.main.ScreenPointToRay(position);
        RaycastHit vHit;
        if (Physics.Raycast(ray.origin, ray.direction, out vHit))
        {
            OnRelativeTapped(vHit.collider.gameObject.GetComponent<ImageController>());
        }
    }

    public void OnRelativeTapped(ImageController tappedRelative)
    {
        // Set default names
        ImageController[] relatives = GetComponentsInChildren<ImageController>();
        foreach (ImageController controller in relatives)
        {
            controller.ResetRelative(defaultName);
        }

        _currentRelative = tappedRelative;
        _currentRelative.SelectRelative("Ich");
        setRelativesNames(0, 0, tappedRelative, false);
    }

    private void setRelativesNames(int generation, int level, ImageController currentRelative, bool affinity)
    {
        List<ImageController> childrenToSearch = new List<ImageController>();
        List<ImageController> parentsToSearch = new List<ImageController>();
        List<ImageController> affinitiesToSearch = new List<ImageController>();
        currentRelative.children.ForEach(child =>
        {
            if (child.MarkedDown)
            {
                string name = GetNameByLevelAndGeneration(child, generation - 1, level + 1, affinity);
                if (name != defaultName)
                {
                    child.UnselectRelative(name);
                    childrenToSearch.Add(child);
                }
            }
        });
        currentRelative.Parents.ForEach(parent =>
        {
            if (parent.MarkedDown)
            {
                string name = GetNameByLevelAndGeneration(parent, generation + 1, level + 1, affinity);
                if (name != defaultName)
                {
                    parent.UnselectRelative(name);
                    parentsToSearch.Add(parent);
                }
            }
        });

        if (!affinity)
        {
            currentRelative.Partners.ForEach(partner =>
            {
                if (partner.MarkedDown)
                {
                    string name = GetNameByLevelAndGeneration(partner, generation, level, true);
                    if (name != defaultName)
                    {
                        partner.UnselectRelative(name);
                        affinitiesToSearch.Add(partner);
                    }
                }
            });
        }

        childrenToSearch.ForEach((child) =>
            setRelativesNames(generation - 1, level + 1, child, affinity)
        );
        parentsToSearch.ForEach((parent) =>
            setRelativesNames(generation + 1, level + 1, parent, affinity)
        );
        affinitiesToSearch.ForEach((parent) =>
            setRelativesNames(generation + 1, level + 1, parent, true)
        );
    }

    private string GetNameByLevelAndGeneration(ImageController relative, int generation, int level, bool affinity)
    {
        switch (relative.sex)
        {
            case (Sex.MALE):
                if (!affinity)
                {
                    if (maleNames.ContainsKey(generation) && maleNames[generation].ContainsKey(level))
                        return maleNames[generation][level];
                }
                else
                {
                    if (affinityMaleNames.ContainsKey(generation) && affinityMaleNames[generation].ContainsKey(level))
                        return affinityMaleNames[generation][level];
                }

                break;

            case (Sex.FEMALE):
                if (!affinity)
                {
                    if (femaleNames.ContainsKey(generation) && femaleNames[generation].ContainsKey(level))
                        return femaleNames[generation][level];
                }
                else
                {
                    if (affinityFemaleNames.ContainsKey(generation) &&
                        affinityFemaleNames[generation].ContainsKey(level))
                        return affinityFemaleNames[generation][level];
                }

                break;
        }

        return defaultName;
    }
}