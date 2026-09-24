namespace LocmanWebServer
{
    // Встроенный веб-интерфейс: три связанных выпадающих списка
    // (город -> улица -> дом), выбор квартир, список жителей и
    // выпадающий список действий (отчёт в Excel / CSV / TXT).
    public static class Index
    {
        public const string Html = @"<!DOCTYPE html>
<html lang='ru'>
<head>
<meta charset='utf-8'>
<meta name='viewport' content='width=device-width, initial-scale=1'>
<title>Лоцман — адресный справочник</title>
<style>
 body{font-family:'Segoe UI',Arial,sans-serif;background:#f0f2f5;margin:0}
 header{background:#1f4e79;color:#fff;padding:14px 24px;font-size:20px}
 .wrap{max-width:1100px;margin:20px auto;padding:0 16px}
 .card{background:#fff;border-radius:8px;box-shadow:0 1px 3px rgba(0,0,0,.15);padding:16px 20px;margin-bottom:16px}
 label{font-weight:600;margin-right:6px;display:inline-block;min-width:70px}
 select,input[type=text]{padding:6px 8px;border:1px solid #bbb;border-radius:4px;font-size:14px}
 .row{margin:8px 0}
 /* Строки «Улица» и «Дом» сдвинуты вправо на 20px; метки фиксированной ширины,
    остальные строки («Квартиры», «Документ») остаются слева, на своём месте */
 .shift{margin-left:20px}
 .row > label{width:90px}
 /* Выпадающие меню с чекбоксами (квартиры) — тот же стиль, что и у обычных select */
 .dd{position:relative;display:inline-block;vertical-align:middle}
 .dd-btn{background:#fff;color:#222;border:1px solid #bbb;border-radius:4px;padding:6px 10px;font-size:14px;cursor:pointer;min-width:230px;text-align:left}
 .dd-btn:after{content:'\\25BE';float:right;color:#777}
 .dd-panel{display:none;position:absolute;top:110%;left:0;z-index:10;background:#fff;border:1px solid #bbb;border-radius:4px;box-shadow:0 2px 6px rgba(0,0,0,.25);padding:8px;width:340px}
 .dd.open .dd-panel{display:block}
 .dd-list{max-height:220px;overflow:auto;column-count:2;margin:6px 0;border-top:1px solid #e3e8ef;padding-top:6px}
 .dd-list label{display:inline-flex;align-items:center;min-width:0;font-weight:400;margin:2px 10px 2px 0;white-space:nowrap}
 .dd-list input{margin-right:4px}
 table{border-collapse:collapse;width:100%}
 th,td{border:1px solid #c9d3de;padding:6px 10px;font-size:14px;text-align:left}
 th{background:#dbe5f1}
 tr:nth-child(even) td{background:#f6f9fc}
 button{background:#1f4e79;color:#fff;border:0;border-radius:4px;padding:8px 14px;font-size:14px;cursor:pointer}
 button:hover{background:#2a6398}
 .muted{color:#777;font-size:13px}
 .err{color:#b00;font-weight:600}
</style>
</head>
<body>
<header>Лоцман — адресный справочник (MSSQL)</header>
<div class='wrap'>

 <div class='card'>
   <div class='row shift'><label>Улица:</label>
     <select id='street'><option value=''>(загрузка…)</option></select></div>
   <div class='row shift'><label>Дом:</label>
     <select id='house'><option value=''>— сначала выберите улицу —</option></select></div>
   <!-- Выпадающий список квартир с чекбоксами: на одном уровне с «Дома»,
        заполняется после выбора дома. Рядок виден всегда (до выбора дома —
        неактивен), чтобы элемент не «появлялся из ниоткуда». -->
   <div class='row' id='flatsRow'><label>Квартиры:</label>
     <span class='dd' id='flatsDd'>
       <button type='button' class='dd-btn' id='flatsDdBtn'>Квартиры: сначала выберите дом</button>
       <span class='dd-panel'>
         <span class='muted'><a href='#' id='selAll'>выделить все</a> |
         <a href='#' id='selNone'>снять все</a></span>
         <div id='flatList' class='dd-list'></div>
       </span>
     </span>
   </div>
   <!-- Выпадающий список документов: на том же уровне, одна запись -->
   <div class='row' id='documentRow'><label>Документ:</label>
     <select id='document'>
       <option value=''>— выберите документ —</option>
       <option value='doc1'>Документ 1</option>
     </select>
   </div>
 </div>

 <div class='card' id='flatsCard' style='display:none'>
   <div class='row'>
     <span style='float:right'>
       <label style='min-width:0'>Действие:</label>
       <select id='flatsAction'>
         <option value=''>— выберите действие —</option>
         <option value='report_xls'>Отчёт в Excel (.xls)</option>
         <option value='report_csv'>Отчёт в CSV (.csv)</option>
         <option value='report_txt'>Отчёт в TXT (.txt)</option>
         <option value='show_residents'>Показать жителей выбранных квартир</option>
         <option value='show_all'>Показать жителей всех квартир дома</option>
       </select>
       <button id='runFlats'>Выполнить</button>
     </span>
   </div>
 </div>

 <div class='card' id='residentsCard' style='display:none'>
   <div class='row'><b id='resTitle'>Жители</b>
     <span style='float:right'>
       <label style='min-width:0'>Действие:</label>
       <select id='resAction'>
         <option value=''>— выберите действие —</option>
         <option value='report_xls'>Отчёт в Excel (.xls)</option>
         <option value='report_csv'>Отчёт в CSV (.csv)</option>
         <option value='report_txt'>Отчёт в TXT (.txt)</option>
       </select>
       <button id='runRes'>Выполнить</button>
     </span>
   </div>
   <div id='resTable'></div>
 </div>

 <div class='card muted' id='status'>Готово.</div>
</div>
<script src='/app.js'></script>
</body>
</html>";

    }
}
