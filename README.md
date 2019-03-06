# ExcelTeamplate
一个通用的Excel模板的导入模板解决方案，导入模板的格式不固定由用户自己控制，后台和数据库自动适配，保证数据能正确存入，提供导入接口服务。

## 设计数据库
1. 使用EntityFramework Core的code first，先通过代码构建模型，然后配置连接字符串，使用数据迁移Add-Migration initDatabase → Update-Database
2. 使用关系型数据库MSSQL
3. 前期暂时不提供会员权限管理
4. 关系图如下：　
![avatar](ftp://45.40.244.84/temp/%E6%95%B0%E6%8D%AE%E5%BA%93%E5%85%B3%E7%B3%BB%E5%9B%BE.png)

## 项目目录结构
![avatar](ftp://45.40.244.84/temp/%E8%A7%A3%E5%86%B3%E6%96%B9%E6%A1%88%E7%9B%AE%E5%BD%95%E7%BB%93%E6%9E%84.png)

## 解决方案说明
+ IDE: VS2017
+ MSSQL: Sql server 2008R2
+ 基础框架: .Net Core 2.2
+ ORM框架: EntityFramework Core
+ 服务端采用ResultFul API，前端采用Vue
+ 作者: 黄文强