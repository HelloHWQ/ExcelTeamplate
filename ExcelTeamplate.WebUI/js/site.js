// // 点击按钮让top里面的按钮消失，同时追加到下面的foot中
// function MoveDiv (divObject)
// {
//   if(divObject.tagName === 'DIV')
//   {
//     $("*top").remove(divObject)
//     $("#foot").append(divObject)
//     // 
//   }
// }

// // 按钮点击事件
// $(function () {
//   // 给class 为top 下的item的按钮绑定点击事件
//   $(".top .item").click(function (){
//     //MoveDiv(this)
//   })
// })

const rownum = 11;
const host = 'https://localhost:5001';
var vm = new Vue({
  el: '#app',
  data: {
    fieldArray: [],
    selectFieldArray: [],
    topBlackNum: 0,
    footBlackNum: 0,
    btnMsg: "选择文件",
    selected: false
  },
  methods: {
    SetBlackNum: function () {
      this.topBlackNum = rownum - (this.fieldArray.length % rownum);
      this.footBlackNum = rownum - (this.selectFieldArray.length % rownum);
    },
    GetFields: function () {
      let that = this
      $.ajax({
        url: host+'/api/field',
        type: 'get',
        async: false,
        success: function (data) {
          // 给fieldArray赋值
          that.fieldArray = data;
          that.SetBlackNum();
        },
        error: function (error) {
          console.log(error);
          that.SetBlackNum();
        }
      })
    },
    // 将按钮移动到已选择的数组中
    MoveToFoot: function (index) {
      var currentItem = this.fieldArray[index];
      // 从未选择中移除
      this.fieldArray.splice(index, 1);
      // 在已选择中添加
      this.selectFieldArray.push(currentItem);
      // 调整空白div的个数
      this.SetBlackNum();
    },
    // 将按钮移动到未选择的数组中
    MoveToTop: function (index) {
      var currentItem = this.selectFieldArray[index];
      // 从已选择中删除
      this.selectFieldArray.splice(index,1);
      // 在未选择中添加
      this.fieldArray.push(currentItem);
      // 调整空白div的个数
      this.SetBlackNum();
    },
    // 打开文件选择器
    OpenFile: function (){
      if(this.selected == false)
      {
        this.$refs.fileSelector.click();
      }
    },
    SelectFile: function () {
      if(this.$refs.fileSelector.value != "")
      {
        this.btnMsg = "已加载文件";
        this.selected = true;
      }
    },
    SubmitForm: function () {
      let formdata = new FormData($("#mainForm")[0]);
      let fields = "";
      this.selectFieldArray.forEach((item) => {
        fields += item.id+",";
      })
      formdata.append("fields",fields);
      $.ajax({
        url: host+'/api/excel',
        type: 'post',
        datatype: 'json',
        contentType: false,
        processData: false,
        data: formdata,
        success: function (data){
          console.log(data);
        },
        error: function (error){
          console.log(error);
        }
      })
    }
  },
  created: function () {
    this.GetFields();
  }
})