using UnityEngine;


namespace Lacobus.Grid
{
    public sealed class GridComponent : MonoBehaviour
    {
        // フィールド

        [SerializeField] private GridComponentDataContainer _gcData;// グリッドの設定データを格納するコンテナ。インスペクターで編集可能。
        [SerializeField] private bool _useSimpleSpriteRendering = false;// シンプルなスプライトレンダリングを使用するかどうかのフラグ。インスペクターで設定可能。
        [SerializeField] private Sprite _defaultSimpleSprite = null;// シンプルスプライトレンダリング時のデフォルトスプライト。インスペクターで設定可能。

        // DefaultCell型のグリッドデータを格納する変数。初期化はAwakeなどで行う
        private Grid<DefaultCell> _grid = null;
        // このコンポーネントがアタッチされているオブジェクトのTransform参照を保持する変数
        private Transform _t;


        // プロパティ

        // Transformをキャッシュして返すプロパティ。_tが未設定の場合は取得してキャッシュする
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
        // グリッドの原点（オリジン）を返すプロパティ。グリッドのオフセットとオブジェクトの現在位置を加算したもの
        private Vector2 gridOrigin
        {
            get
            {
                return _gcData.gridOffset + (Vector2)transform.position;
            }
        }
        // グリッドインスタンスを外部から取得可能にする公開プロパティ
        public Grid<DefaultCell> Grid { get { return _grid; } }


        // パブリックメソッド

        /// <summary>
        /// 指定したインデックスのスプライトを変更するためにこのメソッドを呼び出します
        /// </summary>
        /// <param name="index">対象のインデックス</param>
        /// <param name="targetSprite">対象のスプライト</param>
        public void SetSpriteAt(Vector2Int index, Sprite targetSprite)
        {
            if (_grid.IsInside(index))
                _grid.GetCellData(index).ChangeSprite(targetSprite);
        }

        /// <summary>
        /// 指定したx, yのインデックスのスプライトを変更するためにこのメソッドを呼び出します
        /// </summary>
        /// <param name="x">x インデックス</param>
        /// <param name="y">y インデックス</param>
        /// <param name="targetSprite">対象のスプライト</param>
        public void SetSpriteAt(int x, int y, Sprite targetSprite)
        {
            if (_grid.IsInside(x, y))
                _grid.GetCellData(x, y).ChangeSprite(targetSprite);
        }

        /// <summary>
        /// 指定したワールド座標の位置のスプライトを変更するためにこのメソッドを呼び出します
        /// </summary>
        /// <param name="worldPosition">対象のワールド座標</param>
        /// <param name="targetSprite">対象のスプライト</param>
        public void SetSpriteAt(Vector3 worldPosition, Sprite targetSprite)
        {
            if (_grid.IsInside(worldPosition))
                _grid.GetCellData(worldPosition).ChangeSprite(targetSprite);
        }



        /// <summary>
        /// 指定したインデックスのスプライトカラーを変更するためにこのメソッドを呼び出します
        /// </summary>
        /// <param name="index">対象のインデックス</param>
        /// <param name="targetColor">対象のカラー</param>
        public void SetSpriteColorAt(Vector2Int index, Color targetColor)
        {
            if (_grid.IsInside(index))
                _grid.GetCellData(index).ChangeColor(targetColor);
        }

        /// <summary>
        /// 指定したx, yのインデックスのスプライトカラーを変更するためにこのメソッドを呼び出します
        /// </summary>
        /// <param name="x">x インデックス</param>
        /// <param name="y">y インデックス</param>
        /// <param name="targetColor">対象のカラー</param>
        public void SetSpriteColorAt(int x, int y, Color targetColor)
        {
            if (_grid.IsInside(x, y))
                _grid.GetCellData(x, y).ChangeColor(targetColor);
        }

        /// <summary>
        /// 指定したワールド座標の位置のスプライトカラーを変更するためにこのメソッドを呼び出します
        /// </summary>
        /// <param name="worldPosition">対象のワールド座標</param>
        /// <param name="targetColor">対象のカラー</param>
        public void SetSpriteColorAt(Vector3 worldPosition, Color targetColor)
        {
            if (_grid.IsInside(worldPosition))
                _grid.GetCellData(worldPosition).ChangeColor(targetColor);
        }



        /// <summary>
        /// 指定したインデックスのスプライトサイズを変更するためにこのメソッドを呼び出します
        /// </summary>
        /// <param name="index">対象のインデックス</param>
        /// <param name="size">対象のサイズ</param>
        public void SetSpriteSizeAt(Vector2Int index, Vector2 size)
        {
            if (_grid.IsInside(index))
                _grid.GetCellData(index).ChangeSpriteSize(size);
        }

        /// <summary>
        /// 指定したx, yのインデックスのスプライトサイズを変更するためにこのメソッドを呼び出します
        /// </summary>
        /// <param name="x">x インデックス</param>
        /// <param name="y">y インデックス</param>
        /// <param name="size">対象のサイズ</param>
        public void SetSpriteSizeAt(int x, int y, Vector2 size)
        {
            if (_grid.IsInside(x, y))
                _grid.GetCellData(x, y).ChangeSpriteSize(size);
        }

        /// <summary>
        /// 指定したワールド座標の位置のスプライトサイズを変更するためにこのメソッドを呼び出します
        /// </summary>
        /// <param name="worldPosition">対象のワールド座標</param>
        /// <param name="size">対象のサイズ</param>
        public void SetSpriteSizeAt(Vector2 worldPosition, Vector2 size)
        {
            if (_grid.IsInside(worldPosition))
                _grid.GetCellData(worldPosition).ChangeSpriteSize(size);
        }


        //  ライフサイクルメソッド

        private void Awake()
        {
            _t = transform;

            // ここでグリッドを作成
            _grid = new Grid<DefaultCell>(gridOrigin, _gcData.gridDimension, _gcData.cellDimension);
            _grid.PrepareGrid();

            if (_useSimpleSpriteRendering)
                setupSimpleSpriteRendering();
        }

        /// <summary>
        /// 毎フレーム呼ばれ、グリッドの原点を現在のオフセットとオブジェクトの位置に更新する
        /// </summary>
        private void Update()
        {
            _grid.GridOrigin = _gcData.gridOffset + (Vector2)_t.position;
        }

        /// <summary>
        /// インスペクター上で値が変更されたときに呼ばれ、グリッドを再生成する
        /// </summary>
        private void OnValidate()
        {
            _grid = new Grid<DefaultCell>(gridOrigin, _gcData.gridDimension, _gcData.cellDimension);
        }

        /// <summary>
        /// ギズモ描画時に呼ばれ、ギズモ描画が有効ならグリッド線を描画する
        /// </summary>
        private void OnDrawGizmos()
        {
            if (_gcData.shouldDrawGizmos == false)
                return;

            _grid.GridOrigin = _gcData.gridOffset + (Vector2)transform.position;
            _grid.DrawGridLines(_gcData.gridLineColor, _gcData.crossLineColor);
        }

        /// <summary>
        /// シンプルなスプライトレンダリング用に、グリッド内の各セルに対してGameObjectを生成しセットアップする
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


        // ネスト型

        private enum OffsetType
        {
            Preset,  // プリセット
            Custom   // カスタム
        }

        private enum PresetTypes
        {
            TopRight,     // 右上
            TopCenter,    // 上中央
            TopLeft,      // 左上
            MiddleRight,  // 右中央
            MiddleCenter, // 中央
            MiddleLeft,   // 左中央
            BottomRight,  // 右下
            BottomCenter, // 下中央
            BottomLeft    // 左下
        }

        [System.Serializable]// Unityのインスペクターでこのクラスのフィールドを表示・編集可能にするための属性
        private class GridComponentDataContainer
        {
            // グリッド関連
            [SerializeField]
            // グリッドの幅と高さ（セル数）を表す2次元整数ベクトル
            public Vector2Int gridDimension = new Vector2Int();
            [SerializeField]
            // 1つのセルの幅と高さを表す2次元ベクトル
            public Vector2 cellDimension = new Vector2();
            [SerializeField]
            // グリッド全体のオフセット（座標のずれ）を表す2次元ベクトル
            public Vector2 gridOffset = new Vector2();

            // ギズモとエディター関連

            [SerializeField]
            // オフセットのタイプ（プリセットかカスタムか）を選択する列挙型
            public OffsetType offsetType = OffsetType.Preset;
            [SerializeField]
            // プリセットの基準点（ピボット）を指定する列挙型
            public PresetTypes presetType = PresetTypes.BottomLeft;
            [SerializeField]
            // ギズモ（エディター上の補助線や図形）を描画するかどうかのフラグ
            public bool shouldDrawGizmos = false;
            [SerializeField]
            // グリッドの線の色
            public Color gridLineColor;
            [SerializeField]
            // グリッドの交差点の線の色
            public Color crossLineColor;
        }

        public class DefaultCell
        {
            // フィールド

            public SpriteRenderer sr;


            // パブリックメソッド

            /// <summary>
            /// スプライトレンダラーのスプライトを指定したスプライトに変更します
            /// </summary>
            /// <param name="sprite">設定するスプライト</param>
            public void ChangeSprite(Sprite sprite)
            {
                sr.sprite = sprite;
            }

            /// <summary>
            /// スプライトレンダラーの色を指定したカラーに変更します
            /// </summary>
            /// <param name="color">設定するカラー</param>
            public void ChangeColor(Color color)
            {
                sr.color = color;
            }

            /// <summary>
            /// スプライトレンダラーのサイズ（スケール）を指定したサイズに変更します
            /// </summary>
            /// <param name="size">設定するサイズ（スケール）</param>
            public void ChangeSpriteSize(Vector2 size)
            {
                sr.transform.localScale = size;
            }
        }
    }
}