using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RelativeController : MonoBehaviour
{
    private ImageController[] _relatives;

    private List<Dictionary<int, string>> relativesNames = new List<Dictionary<int, string>>();

    // Start is called before the first frame update

    void Start()
    {
        fillRelativesNames();
        _relatives = GetComponentsInChildren<ImageController>();
    }

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Ended)
            {
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                RaycastHit vHit;
                if(Physics.Raycast(ray.origin,ray.direction, out vHit))
                {
                    OnRelativeTapped(vHit.collider.gameObject);
                }
            }
        }
    }

    public void OnRelativeTapped(GameObject tappedRelative)
    {
        ImageController imageController = tappedRelative.GetComponent<ImageController>();
        Dictionary<int, string> names = relativesNames[imageController.Position];
        foreach (ImageController relative in _relatives)
        {
            relative.setText(names[relative.Position]);
        }
        
        // highlight tapped button
        Image image = tappedRelative.GetComponent<Image>();
        image.color = Color.cyan;
    }

    private void fillRelativesNames()
    {
        // relativesNames.Add(new Dictionary<int, string>
        // {
        //     {0, ""}, {1, ""}, {2, ""}, {3, ""}, // wmwm
        //     {4, ""}, {5, ""}, // wm
        //     {6, ""}, {7, ""}, {8, ""}, {9, ""}, {10, ""}, //wmmwm
        //     {11, ""}, {12, ""}, {13, ""}, {14, ""}, {15, ""}, {16, ""}, {17, ""}, //mwwmwmw
        //     {18, ""}, {19, ""}, {20, ""}, {21, ""}, //wmwm
        // });

        // 1. Row
        relativesNames.Add(new Dictionary<int, string>
        {
            {0, "Du"}, {1, "Ehemann"}, {2, "Gegenschwiegermutter"}, {3, "Gegenschwiegervater"}, // wmwm
            {4, "Tochter"}, {5, "Schwiegersohn"}, // wm
            {6, "Schwiegerenkelin"}, {7, "Enkel"}, {8, "Enkel"}, {9, "Enkelin"}, {10, "Schwiegerenkel"}, //wmmwm
            {11, "Urenkel"}, {12, "Urenkelin"}, {13, "Urenkelin"}, {14, "Schwiegerurenkel"}, {15, "Schwiegerurenkelin"},
            {16, "Urenkel"}, {17, "Urenkelin"}, //mwwmwmw
            {18, "Ururenkelin"}, {19, "Ururenkel"}, {20, "Ururenkelin"}, {21, "Ururenkel"}, //wmwm
        });

        relativesNames.Add(new Dictionary<int, string>
        {
            {0, "Ehefrau"}, {1, "Du"}, {2, "Gegenschwiegermutter"}, {3, "Gegenschwiegervater"}, // wmwm
            {4, "Tochter"}, {5, "Schwiegersohn"}, // wm
            {6, "Schwiegerenkelin"}, {7, "Enkel"}, {8, "Enkel"}, {9, "Enkelin"}, {10, "Schwiegerenkel"}, //wmmwm
            {11, "Urenkel"}, {12, "Urenkelin"}, {13, "Urenkelin"}, {14, "Schwiegerurenkel"}, {15, "Schwiegerurenkelin"},
            {16, "Urenkel"}, {17, "Urenkelin"}, //mwwmwmw
            {18, "Ururenkelin"}, {19, "Ururenkel"}, {20, "Ururenkelin"}, {21, "Ururenkel"}, //wmwm
        });

        relativesNames.Add(new Dictionary<int, string>
        {
            {0, "Gegenschwiegermutter"}, {1, "Gegenschwiegervater"}, {2, "Du"}, {3, "Ehemann"}, // wmwm
            {4, "Schwiegertochter"}, {5, "Sohn"}, // wm
            {6, "Schwiegerenkelin"}, {7, "Enkel"}, {8, "Enkel"}, {9, "Enkelin"}, {10, "Schwiegerenkel"}, //wmmwm
            {11, "Urenkel"}, {12, "Urenkelin"}, {13, "Urenkelin"}, {14, "Schwiegerurenkel"}, {15, "Schwiegerurenkelin"},
            {16, "Urenkel"}, {17, "Urenkelin"}, //mwwmwmw
            {18, "Ururenkelin"}, {19, "Ururenkel"}, {20, "Ururenkelin"}, {21, "Ururenkel"}, //wmwm
        });

        relativesNames.Add(new Dictionary<int, string>
        {
            {0, "Gegenschwiegermutter"}, {1, "Gegenschwiegervater"}, {2, "Du"}, {3, "Ehemann"}, // wmwm
            {4, "Schwiegertochter"}, {5, "Sohn"}, // wm
            {6, "Schwiegerenkelin"}, {7, "Enkel"}, {8, "Enkel"}, {9, "Enkelin"}, {10, "Schwiegerenkel"}, //wmmwm
            {11, "Urenkel"}, {12, "Urenkelin"}, {13, "Urenkelin"}, {14, "Schwiegerurenkel"}, {15, "Schwiegerurenkelin"},
            {16, "Urenkel"}, {17, "Urenkelin"}, //mwwmwmw
            {18, "Ururenkelin"}, {19, "Ururenkel"}, {20, "Ururenkelin"}, {21, "Ururenkel"}, //wmwm
        });

        //2. Row
        relativesNames.Add(new Dictionary<int, string>
        {
            {0, "Mutter"}, {1, "Vater"}, {2, "Schiegermutter"}, {3, "Schwiegervater"}, // wmwm
            {4, "Du"}, {5, "Ehemann"}, // wm
            {6, "Schwiegertochter"}, {7, "Sohn"}, {8, "Sohn"}, {9, "Tochter"}, {10, "Schwiegersohn"}, //wmmwm
            {11, "Enkel"}, {12, "Enkelin"}, {13, "Enkelin"}, {14, "Schwiegerenkel"}, {15, "Schwiegerenkelin"},
            {16, "Enkel"}, {17, "Enkelin"}, //mwwmwmw
            {18, "Urenkelin"}, {19, "Urenkel"}, {20, "Urenkelin"}, {21, "Urenkel"}, //wmwm
        });
        relativesNames.Add(new Dictionary<int, string>
        {
            {0, "Schiegermutter"}, {1, "Schwiegervater"}, {2, "Mutter"}, {3, "Vater"}, // wmwm
            {4, "Ehefrau"}, {5, "Du"}, // wm
            {6, "Schwiegertochter"}, {7, "Sohn"}, {8, "Sohn"}, {9, "Tochter"}, {10, "Schwiegersohn"}, //wmmwm
            {11, "Enkel"}, {12, "Enkelin"}, {13, "Enkelin"}, {14, "Schwiegerenkel"}, {15, "Schwiegerenkelin"},
            {16, "Enkel"}, {17, "Enkelin"}, //mwwmwmw
            {18, "Urenkelin"}, {19, "Urenkel"}, {20, "Urenkelin"}, {21, "Urenkel"}, //wmwm
        });

        //3. Row
        relativesNames.Add(new Dictionary<int, string>
        {
            {0, "Vater der Schwiegermutter"}, {1, "Mutter der Schwiegermutter"}, {2, "Vater des Schwiegervaters"},
            {3, "Mutter des Schwiegervaters"}, // wmwm
            {4, "Schwiegermutter"}, {5, "Schwiegervater"}, // wm
            {6, "Du"}, {7, "Ehemann"}, {8, "Schwiegerbruder"}, {9, "Schwiegerschwester"},
            {10, "Schwippschwager"}, //wmmwm
            {11, "Sohn"}, {12, "Tochter"}, {13, "Tochter"}, {14, "Schwiegersohn"}, {15, "Schwiegernichte"},
            {16, "Neffe"}, {17, "Nichte"}, //mwwmwmw
            {18, "Enkelin"}, {19, "Enkel"}, {20, "Großnichte"}, {21, "Großneffe"}, //wmwm
        });
        relativesNames.Add(new Dictionary<int, string>
        {
            {0, "Großmutter"}, {1, "Großvater"}, {2, "Großmutter"}, {3, "Großvater"}, // wmwm
            {4, "Mutter"}, {5, "Vater"}, // wm
            {6, "Ehefrau"}, {7, "Du"}, {8, "Bruder"}, {9, "Schwester"}, {10, "Schwiegerbruder"}, //wmmwm
            {11, "Sohn"}, {12, "Tochter"}, {13, "Tochter"}, {14, "Schwiegersohn"}, {15, "Schwiegernichte"},
            {16, "Neffe"}, {17, "Nichte"}, //mwwmwmw
            {18, "Enkelin"}, {19, "Enkel"}, {20, "Großnichte"}, {21, "Großneffe"}, //wmwm
        });
        relativesNames.Add(new Dictionary<int, string>
        {
            {0, "Großmutter"}, {1, "Großvater"}, {2, "Großmutter"}, {3, "Großvater"}, // wmwm
            {4, "Mutter"}, {5, "Vater"}, // wm
            {6, "Schwiegerschwester"}, {7, "Bruder"}, {8, "Du"}, {9, "Schwester"}, {10, "Schwiegerbruder"}, //wmmwm
            {11, "Neffe"}, {12, "Nichte"}, {13, "Nichte"}, {14, "Schwiegerneffe"}, {15, "Schwiegernichte"},
            {16, "Neffe"}, {17, "Nichte"}, //mwwmwmw
            {18, "Großnichte"}, {19, "Großneffe"}, {20, "Großnichte"}, {21, "Großneffe"}, //wmwm
        });
        relativesNames.Add(new Dictionary<int, string>
        {
            {0, "Großmutter"}, {1, "Großvater"}, {2, "Großmutter"}, {3, "Großvater"}, // wmwm
            {4, "Mutter"}, {5, "Vater"}, // wm
            {6, "Schwiegerschwester"}, {7, "Bruder"}, {8, "Bruder"}, {9, "Du"}, {10, "Ehemann"}, //wmmwm
            {11, "Neffe"}, {12, "Nichte"}, {13, "Nichte"}, {14, "Schwiegerneffe"}, {15, "Schwiegertochter"},
            {16, "Sohn"}, {17, "Tochter"}, //mwwmwmw
            {18, "Großnichte"}, {19, "Großneffe"}, {20, "Enkelin"}, {21, "Enkel"}, //wmwm
        });
        relativesNames.Add(new Dictionary<int, string>
        {
            {0, "Vater der Schwiegermutter"}, {1, "Mutter der Schwiegermutter"}, {2, "Vater des Schwiegervaters"},
            {3, "Mutter des Schwiegervaters"}, // wmwm
            {4, "Schwiegermutter"}, {5, "Schwiegervater"}, // wm
            {6, "Schwippschwägerin"}, {7, "Schwiegerbruder"}, {8, "Schwiegerbruder"}, {9, "Ehefrau"},
            {10, "Du"}, //wmmwm
            {11, "Neffe"}, {12, "Nichte"}, {13, "Nichte"}, {14, "Schwiegerneffe"}, {15, "Schwiegertochter"},
            {16, "Sohn"}, {17, "Tochter"}, //mwwmwmw
            {18, "Großnichte"}, {19, "Großneffe"}, {20, "Enkelin"}, {21, "Enkel"}, //wmwm
        });

        // 4. Row
        relativesNames.Add(new Dictionary<int, string>
        {
            {0, "Urgroßmutter"}, {1, "Urgroßvater"}, {2, "Urgroßmutter"}, {3, "Urgroßvater"}, // wmwm
            {4, "Großmutter"}, {5, "Großvater"}, // wm
            {6, "Mutter"}, {7, "Vater"}, {8, "Onkel"}, {9, "Tante"}, {10, "Onkel"}, //wmmwm
            {11, "Du"}, {12, "Schwester"}, {13, "Schwester"}, {14, "Schwiegerbruder"}, {15, "Schwiegercousine"},
            {16, "Cousin"}, {17, "Cousine"}, //mwwmwmw
            {18, "Nichte"}, {19, "Neffe"}, {20, "Nichte 2. Grades"}, {21, "Neffe 2. Grades"}, //wmwm
        });
        relativesNames.Add(new Dictionary<int, string>
        {
            {0, "Urgroßmutter"}, {1, "Urgroßvater"}, {2, "Urgroßmutter"}, {3, "Urgroßvater"}, // wmwm
            {4, "Großmutter"}, {5, "Großvater"}, // wm
            {6, "Mutter"}, {7, "Vater"}, {8, "Onkel"}, {9, "Tante"}, {10, "Onkel"}, //wmmwm
            {11, "Bruder"}, {12, "Du"}, {13, "Zwillingsschwester"}, {14, "Schwiegerbruder"}, {15, "Schwiegercousine"},
            {16, "Cousin"}, {17, "Cousine"}, //mwwmwmw
            {18, "Nichte"}, {19, "Neffe"}, {20, "Nichte 2. Grades"}, {21, "Neffe 2. Grades"}, //wmwm
        });
        relativesNames.Add(new Dictionary<int, string>
        {
            {0, "Urgroßmutter"}, {1, "Urgroßvater"}, {2, "Urgroßmutter"}, {3, "Urgroßvater"}, // wmwm
            {4, "Großmutter"}, {5, "Großvater"}, // wm
            {6, "Mutter"}, {7, "Vater"}, {8, "Onkel"}, {9, "Tante"}, {10, "Onkel"}, //wmmwm
            {11, "Bruder"}, {12, "Zwillingsschwester"}, {13, "Du"}, {14, "Ehemann"}, {15, "Schwiegercousine"},
            {16, "Cousin"}, {17, "Cousine"}, //mwwmwmw
            {18, "Tochter"}, {19, "Sohn"}, {20, "Nichte 2. Grades"}, {21, "Neffe 2. Grades"}, //wmwm
        });
        relativesNames.Add(new Dictionary<int, string>
        {
            {0, "Urgroßschwiegermutter"}, {1, "Urgroßschwiegervater"}, {2, "Urgroßschwiegermutter"},
            {3, "Urgroßschwiegervater"}, // wmwm
            {4, "Großschwiegermutter"}, {5, "Großschwiegervater"}, // wm
            {6, "Schwiegermutter"}, {7, "Schwiegervater"}, {8, "Schwiegeronkel"}, {9, "Schwiegertante"},
            {10, "Schwiegeronkel"}, //wmmwm
            {11, "Schwiegerbruder"}, {12, "Schwiegerschwester"}, {13, "Ehefrau"}, {14, "Du"},
            {15, "Ehefrau meines Schwiegercousins"}, {16, "Schwiegercousin"}, {17, "Schwiegercousine"}, //mwwmwmw
            {18, "Tochter"}, {19, "Sohn"}, {20, "Tochter deines Schwiegercousins"},
            {21, "Sohn deines Schwiegercousins"}, //wmwm
        });
        relativesNames.Add(new Dictionary<int, string>
        {
            {0, "Urgroßschwiegermutter"}, {1, "Urgroßschwiegervater"}, {2, "Urgroßschwiegermutter"},
            {3, "Urgroßschwiegervater"}, // wmwm
            {4, "Großschwiegermutter"}, {5, "Großschwiegervater"}, // wm
            {6, "Schwiegertante"}, {7, "Schwiegeronkel"}, {8, "Schwiegeronkel"}, {9, "Schwiegermutter"},
            {10, "Schwiegervater"}, //wmmwm
            {11, "Schwiegercousin"}, {12, "Schwiegercousine"}, {13, "Schwiegercousine"},
            {14, "Ehefrau meiner Schwiegercousine"}, {15, "Du"}, {16, "Ehemann"}, {17, "Schwiegerschwester"}, //mwwmwmw
            {18, "Tochter deiner Schwiegercousine"}, {19, "Sohn deiner Schwiegercousine"}, {20, "Tochter"},
            {21, "Sohn"}, //wmwm
        });
        relativesNames.Add(new Dictionary<int, string>
        {
            {0, "Urgroßmutter"}, {1, "Urgroßvater"}, {2, "Urgroßmutter"}, {3, "Urgroßvater"}, // wmwm
            {4, "Großmutter"}, {5, "Großvater"}, // wm
            {6, "Tante"}, {7, "Onkel"}, {8, "Onkel"}, {9, "Mutter"}, {10, "Vater"}, //wmmwm
            {11, "Cousin"}, {12, "Cousine"}, {13, "Cousine"}, {14, "Schwiegercousin"}, {15, "Ehefrau"}, {16, "Du"},
            {17, "Schwester"}, //mwwmwmw
            {18, "Nichte 2. Grades"}, {19, "Neffe 2. Grades"}, {20, "Tochter"}, {21, "Sohn"}, //wmwm
        });
        relativesNames.Add(new Dictionary<int, string>
        {
            {0, "Urgroßmutter"}, {1, "Urgroßvater"}, {2, "Urgroßmutter"}, {3, "Urgroßvater"}, // wmwm
            {4, "Großmutter"}, {5, "Großvater"}, // wm
            {6, "Tante"}, {7, "Onkel"}, {8, "Onkel"}, {9, "Mutter"}, {10, "Vater"}, //wmmwm
            {11, "Cousin"}, {12, "Cousine"}, {13, "Cousine"}, {14, "Schwiegercousin"}, {15, "Schwiegerschwester"},
            {16, "Bruder"}, {17, "Du"}, //mwwmwmw
            {18, "Nichte 2. Grades"}, {19, "Neffe 2. Grades"}, {20, "Nichte"}, {21, "Neffe"}, //wmwm
        });

        // 5. Row
        relativesNames.Add(new Dictionary<int, string>
        {
            {0, "Ururgroßmutter"}, {1, "Ururgroßvater"}, {2, "Ururgroßmutter"}, {3, "Ururgroßvater"}, // wmwm
            {4, "Urgroßmutter"}, {5, "Urgroßvater"}, // wm
            {6, "Großmutter"}, {7, "Großvater"}, {8, "Großonkel"}, {9, "Großtante"}, {10, "Großonkel"}, //wmmwm
            {11, "Onkel"}, {12, "Tante"}, {13, "Mutter"}, {14, "Vater"}, {15, "Tante 3. Grades"},
            {16, "Onkel 3. Grades"}, {17, "Tante 3. Grades"}, //mwwmwmw
            {18, "Du"}, {19, "Bruder"}, {20, "Cousine 3. Grades"}, {21, "Cousin 3. Grades"}, //wmwm
        });
        relativesNames.Add(new Dictionary<int, string>
        {
            {0, "Ururgroßmutter"}, {1, "Ururgroßvater"}, {2, "Ururgroßmutter"}, {3, "Ururgroßvater"}, // wmwm
            {4, "Urgroßmutter"}, {5, "Urgroßvater"}, // wm
            {6, "Großmutter"}, {7, "Großvater"}, {8, "Großonkel"}, {9, "Großtante"}, {10, "Großonkel"}, //wmmwm
            {11, "Onkel"}, {12, "Tante"}, {13, "Mutter"}, {14, "Vater"}, {15, "Tante 3. Grades"},
            {16, "Onkel 3. Grades"}, {17, "Tante 3. Grades"}, //mwwmwmw
            {18, "Schwester"}, {19, "Du"}, {20, "Cousine 3. Grades"}, {21, "Cousin 3. Grades"}, //wmwm
        });
        relativesNames.Add(new Dictionary<int, string>
        {
            {0, "Ururgroßmutter"}, {1, "Ururgroßvater"}, {2, "Ururgroßmutter"}, {3, "Ururgroßvater"}, // wmwm
            {4, "Urgroßmutter"}, {5, "Urgroßvater"}, // wm
            {6, "Großonkel"}, {7, "Großtante"}, {8, "Großonkel"}, {9, "Großmutter"}, {10, "Großvater"}, //wmmwm
            {11, "Onkel 3. Grades"}, {12, "Tante 3. Grades"}, {13, "Tante 3. Grades"}, {14, "Onkel 3. Grades"},
            {15, "Mutter"}, {16, "Vater"}, {17, "Tante"}, //mwwmwmw
            {18, "Cousine 3. Grades"}, {19, "Cousin 3. Grades"}, {20, "Du"}, {21, "Bruder"}, //wmwm
        });
        relativesNames.Add(new Dictionary<int, string>
        {
            {0, "Ururgroßmutter"}, {1, "Ururgroßvater"}, {2, "Ururgroßmutter"}, {3, "Ururgroßvater"}, // wmwm
            {4, "Urgroßmutter"}, {5, "Urgroßvater"}, // wm
            {6, "Großonkel"}, {7, "Großtante"}, {8, "Großonkel"}, {9, "Großmutter"}, {10, "Großvater"}, //wmmwm
            {11, "Onkel 3. Grades"}, {12, "Tante 3. Grades"}, {13, "Tante 3. Grades"}, {14, "Onkel 3. Grades"},
            {15, "Mutter"}, {16, "Vater"}, {17, "Tante"}, //mwwmwmw
            {18, "Cousine 3. Grades"}, {19, "Cousin 3. Grades"}, {20, "Schwester"}, {21, "Du"}, //wmwm
        });
    }
}