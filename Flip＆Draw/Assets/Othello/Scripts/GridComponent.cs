using UnityEngine;


namespace Lacobus.Grid
{
    public sealed class GridComponent : MonoBehaviour
    {
        // �t�B�[���h

        [SerializeField] private GridComponentDataContainer _gcData;// �O���b�h�̐ݒ�f�[�^���i�[����R���e�i�B�C���X�y�N�^�[�ŕҏW�\�B
        [SerializeField] private bool _useSimpleSpriteRendering = false;// �V���v���ȃX�v���C�g�����_�����O���g�p���邩�ǂ����̃t���O�B�C���X�y�N�^�[�Őݒ�\�B
        [SerializeField] private Sprite _defaultSimpleSprite = null;// �V���v���X�v���C�g�����_�����O���̃f�t�H���g�X�v���C�g�B�C���X�y�N�^�[�Őݒ�\�B

        // DefaultCell�^�̃O���b�h�f�[�^���i�[����ϐ��B��������Awake�Ȃǂōs��
        private Grid<DefaultCell> _grid = null;
        // ���̃R���|�[�l���g���A�^�b�`����Ă���I�u�W�F�N�g��Transform�Q�Ƃ�ێ�����ϐ�
        private Transform _t;


        // �v���p�e�B

        // Transform���L���b�V�����ĕԂ��v���p�e�B�B_t�����ݒ�̏ꍇ�͎擾���ăL���b�V������
        private Transform t
        {
            get
            {
                if (_t)
                    return _t;
                else
                {
                    _t = transform;
                    return _t;
                }
            }
        }
        // �O���b�h�̌��_�i�I���W���j��Ԃ��v���p�e�B�B�O���b�h�̃I�t�Z�b�g�ƃI�u�W�F�N�g�̌��݈ʒu�����Z��������
        private Vector2 gridOrigin
        {
            get
            {
                return _gcData.gridOffset + (Vector2)transform.position;
            }
        }
        // �O���b�h�C���X�^���X���O������擾�\�ɂ�����J�v���p�e�B
        public Grid<DefaultCell> Grid { get { return _grid; } }


        // �p�u���b�N���\�b�h

        /// <summary>
        /// �w�肵���C���f�b�N�X�̃X�v���C�g��ύX���邽�߂ɂ��̃��\�b�h���Ăяo���܂�
        /// </summary>
        /// <param name="index">�Ώۂ̃C���f�b�N�X</param>
        /// <param name="targetSprite">�Ώۂ̃X�v���C�g</param>
        public void SetSpriteAt(Vector2Int index, Sprite targetSprite)
        {
            if (_grid.IsInside(index))
                _grid.GetCellData(index).ChangeSprite(targetSprite);
        }

        /// <summary>
        /// �w�肵��x, y�̃C���f�b�N�X�̃X�v���C�g��ύX���邽�߂ɂ��̃��\�b�h���Ăяo���܂�
        /// </summary>
        /// <param name="x">x �C���f�b�N�X</param>
        /// <param name="y">y �C���f�b�N�X</param>
        /// <param name="targetSprite">�Ώۂ̃X�v���C�g</param>
        public void SetSpriteAt(int x, int y, Sprite targetSprite)
        {
            if (_grid.IsInside(x, y))
                _grid.GetCellData(x, y).ChangeSprite(targetSprite);
        }

        /// <summary>
        /// �w�肵�����[���h���W�̈ʒu�̃X�v���C�g��ύX���邽�߂ɂ��̃��\�b�h���Ăяo���܂�
        /// </summary>
        /// <param name="worldPosition">�Ώۂ̃��[���h���W</param>
        /// <param name="targetSprite">�Ώۂ̃X�v���C�g</param>
        public void SetSpriteAt(Vector3 worldPosition, Sprite targetSprite)
        {
            if (_grid.IsInside(worldPosition))
                _grid.GetCellData(worldPosition).ChangeSprite(targetSprite);
        }



        /// <summary>
        /// �w�肵���C���f�b�N�X�̃X�v���C�g�J���[��ύX���邽�߂ɂ��̃��\�b�h���Ăяo���܂�
        /// </summary>
        /// <param name="index">�Ώۂ̃C���f�b�N�X</param>
        /// <param name="targetColor">�Ώۂ̃J���[</param>
        public void SetSpriteColorAt(Vector2Int index, Color targetColor)
        {
            if (_grid.IsInside(index))
                _grid.GetCellData(index).ChangeColor(targetColor);
        }

        /// <summary>
        /// �w�肵��x, y�̃C���f�b�N�X�̃X�v���C�g�J���[��ύX���邽�߂ɂ��̃��\�b�h���Ăяo���܂�
        /// </summary>
        /// <param name="x">x �C���f�b�N�X</param>
        /// <param name="y">y �C���f�b�N�X</param>
        /// <param name="targetColor">�Ώۂ̃J���[</param>
        public void SetSpriteColorAt(int x, int y, Color targetColor)
        {
            if (_grid.IsInside(x, y))
                _grid.GetCellData(x, y).ChangeColor(targetColor);
        }

        /// <summary>
        /// �w�肵�����[���h���W�̈ʒu�̃X�v���C�g�J���[��ύX���邽�߂ɂ��̃��\�b�h���Ăяo���܂�
        /// </summary>
        /// <param name="worldPosition">�Ώۂ̃��[���h���W</param>
        /// <param name="targetColor">�Ώۂ̃J���[</param>
        public void SetSpriteColorAt(Vector3 worldPosition, Color targetColor)
        {
            if (_grid.IsInside(worldPosition))
                _grid.GetCellData(worldPosition).ChangeColor(targetColor);
        }



        /// <summary>
        /// �w�肵���C���f�b�N�X�̃X�v���C�g�T�C�Y��ύX���邽�߂ɂ��̃��\�b�h���Ăяo���܂�
        /// </summary>
        /// <param name="index">�Ώۂ̃C���f�b�N�X</param>
        /// <param name="size">�Ώۂ̃T�C�Y</param>
        public void SetSpriteSizeAt(Vector2Int index, Vector2 size)
        {
            if (_grid.IsInside(index))
                _grid.GetCellData(index).ChangeSpriteSize(size);
        }

        /// <summary>
        /// �w�肵��x, y�̃C���f�b�N�X�̃X�v���C�g�T�C�Y��ύX���邽�߂ɂ��̃��\�b�h���Ăяo���܂�
        /// </summary>
        /// <param name="x">x �C���f�b�N�X</param>
        /// <param name="y">y �C���f�b�N�X</param>
        /// <param name="size">�Ώۂ̃T�C�Y</param>
        public void SetSpriteSizeAt(int x, int y, Vector2 size)
        {
            if (_grid.IsInside(x, y))
                _grid.GetCellData(x, y).ChangeSpriteSize(size);
        }

        /// <summary>
        /// �w�肵�����[���h���W�̈ʒu�̃X�v���C�g�T�C�Y��ύX���邽�߂ɂ��̃��\�b�h���Ăяo���܂�
        /// </summary>
        /// <param name="worldPosition">�Ώۂ̃��[���h���W</param>
        /// <param name="size">�Ώۂ̃T�C�Y</param>
        public void SetSpriteSizeAt(Vector2 worldPosition, Vector2 size)
        {
            if (_grid.IsInside(worldPosition))
                _grid.GetCellData(worldPosition).ChangeSpriteSize(size);
        }


        //  ���C�t�T�C�N�����\�b�h

        private void Awake()
        {
            _t = transform;

            // �����ŃO���b�h���쐬
            _grid = new Grid<DefaultCell>(gridOrigin, _gcData.gridDimension, _gcData.cellDimension);
            _grid.PrepareGrid();

            if (_useSimpleSpriteRendering)
                setupSimpleSpriteRendering();
        }

        /// <summary>
        /// ���t���[���Ă΂�A�O���b�h�̌��_�����݂̃I�t�Z�b�g�ƃI�u�W�F�N�g�̈ʒu�ɍX�V����
        /// </summary>
        private void Update()
        {
            _grid.GridOrigin = _gcData.gridOffset + (Vector2)_t.position;
        }

        /// <summary>
        /// �C���X�y�N�^�[��Œl���ύX���ꂽ�Ƃ��ɌĂ΂�A�O���b�h���Đ�������
        /// </summary>
        private void OnValidate()
        {
            _grid = new Grid<DefaultCell>(gridOrigin, _gcData.gridDimension, _gcData.cellDimension);
        }

        /// <summary>
        /// �M�Y���`�掞�ɌĂ΂�A�M�Y���`�悪�L���Ȃ�O���b�h����`�悷��
        /// </summary>
        private void OnDrawGizmos()
        {
            if (_gcData.shouldDrawGizmos == false)
                return;

            _grid.GridOrigin = _gcData.gridOffset + (Vector2)transform.position;
            _grid.DrawGridLines(_gcData.gridLineColor, _gcData.crossLineColor);
        }

        /// <summary>
        /// �V���v���ȃX�v���C�g�����_�����O�p�ɁA�O���b�h���̊e�Z���ɑ΂���GameObject�𐶐����Z�b�g�A�b�v����
        /// </summary>
        private void setupSimpleSpriteRendering()
        {
            foreach (var c in _grid)
            {
                GameObject go = new GameObject($"{c.Index}", typeof(SpriteRenderer));

                c.Data.sr = go.GetComponent<SpriteRenderer>();
                c.Data.sr.sprite = _defaultSimpleSprite;

                go.transform.parent = _t;
                go.transform.position = _grid.GetCellCenter(c.Index);
                go.transform.localScale = _grid.CellDimension;
            }
        }


        // �l�X�g�^

        private enum OffsetType
        {
            Preset,  // �v���Z�b�g
            Custom   // �J�X�^��
        }

        private enum PresetTypes
        {
            TopRight,     // �E��
            TopCenter,    // �㒆��
            TopLeft,      // ����
            MiddleRight,  // �E����
            MiddleCenter, // ����
            MiddleLeft,   // ������
            BottomRight,  // �E��
            BottomCenter, // ������
            BottomLeft    // ����
        }

        [System.Serializable]// Unity�̃C���X�y�N�^�[�ł��̃N���X�̃t�B�[���h��\���E�ҏW�\�ɂ��邽�߂̑���
        private class GridComponentDataContainer
        {
            // �O���b�h�֘A
            [SerializeField]
            // �O���b�h�̕��ƍ����i�Z�����j��\��2���������x�N�g��
            public Vector2Int gridDimension = new Vector2Int();
            [SerializeField]
            // 1�̃Z���̕��ƍ�����\��2�����x�N�g��
            public Vector2 cellDimension = new Vector2();
            [SerializeField]
            // �O���b�h�S�̂̃I�t�Z�b�g�i���W�̂���j��\��2�����x�N�g��
            public Vector2 gridOffset = new Vector2();

            // �M�Y���ƃG�f�B�^�[�֘A

            [SerializeField]
            // �I�t�Z�b�g�̃^�C�v�i�v���Z�b�g���J�X�^�����j��I������񋓌^
            public OffsetType offsetType = OffsetType.Preset;
            [SerializeField]
            // �v���Z�b�g�̊�_�i�s�{�b�g�j���w�肷��񋓌^
            public PresetTypes presetType = PresetTypes.BottomLeft;
            [SerializeField]
            // �M�Y���i�G�f�B�^�[��̕⏕����}�`�j��`�悷�邩�ǂ����̃t���O
            public bool shouldDrawGizmos = false;
            [SerializeField]
            // �O���b�h�̐��̐F
            public Color gridLineColor;
            [SerializeField]
            // �O���b�h�̌����_�̐��̐F
            public Color crossLineColor;
        }

        public class DefaultCell
        {
            // �t�B�[���h

            public SpriteRenderer sr;


            // �p�u���b�N���\�b�h

            /// <summary>
            /// �X�v���C�g�����_���[�̃X�v���C�g���w�肵���X�v���C�g�ɕύX���܂�
            /// </summary>
            /// <param name="sprite">�ݒ肷��X�v���C�g</param>
            public void ChangeSprite(Sprite sprite)
            {
                sr.sprite = sprite;
            }

            /// <summary>
            /// �X�v���C�g�����_���[�̐F���w�肵���J���[�ɕύX���܂�
            /// </summary>
            /// <param name="color">�ݒ肷��J���[</param>
            public void ChangeColor(Color color)
            {
                sr.color = color;
            }

            /// <summary>
            /// �X�v���C�g�����_���[�̃T�C�Y�i�X�P�[���j���w�肵���T�C�Y�ɕύX���܂�
            /// </summary>
            /// <param name="size">�ݒ肷��T�C�Y�i�X�P�[���j</param>
            public void ChangeSpriteSize(Vector2 size)
            {
                sr.transform.localScale = size;
            }
        }
    }
}